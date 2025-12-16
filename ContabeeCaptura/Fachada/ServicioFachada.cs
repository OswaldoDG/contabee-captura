using ContabeeApi;
using ContabeeApi.Auth;
using ContabeeApi.Blob;
using ContabeeApi.Modelos.Captura;
using ContabeeApi.Archivos;
using ContabeeApi.Vision;
using ContabeeComunes;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ContabeeApi.XML;

namespace ContabeeCaptura.Fachada
{
    public class ServicioFachada : IServicioFachada
    {
        private readonly IApiContabee _api;
        private readonly IHubEventos _hub;
        private readonly IServicioBlob _blob;
        private readonly IServicioVision _vision;
        private readonly IServicioArchivos _archivos;
        private readonly IServicioAuth _auth;
        private readonly IServicioXML _xml;

        private Guid _subDescarga;
        private Guid _subFinalizar;

        private PaginaTrabajoCapturaCloud _pagina;

        public ServicioFachada(IApiContabee api, IHubEventos hub, IServicioBlob blob, IServicioVision vision, IServicioAuth auth, IServicioXML xml)
        {
            _api = api;
            _hub = hub;
            _vision = vision;
            _blob = blob;
            _auth = auth;
            _xml = xml;
            _subDescarga = _hub.Suscribir<DescargaDetectadaMensaje>(OnDescargaDetectada);
            _subFinalizar = _hub.Suscribir<SolicitarCompletarCapturaMensaje>(OnSolicitarCompletar);
        }

        public async Task SiguienteTrabajoAsync()
        {
            if (!await _auth.AsegurarSesionValidaAsync())
            {
                _hub.Publicar(new NotificacionUIEvent(this, "Refresco de Autorización.", TipoNotificacion.Info));

                return;
            }


            _hub.Publicar(new MensajeClear { Sender = this });

            var datos = await _api.ObtienePagina();

            _hub.Publicar(new DatosFiscalesMensaje
            {
                Sender = this,
                Datos = datos.Payload
            });

            _hub.Publicar(new NombreBlobMensaje 
            {
                Sender= this,
                NombreBlob = datos.Payload.Ruta
            });

            var bytesImagen = await _blob.DescargaImagenSaSAsync(datos.Payload.TokenSas);
            byte[] Imagen = bytesImagen.Payload;

            if (Imagen != null && Imagen.Length > 0)
            {
                string textoOcr = string.Empty;

                using (var msOcr = new MemoryStream(Imagen))
                {
                    var r = await _vision.TextoOCR(msOcr);
                    textoOcr = r.Payload;
                }

                if (!string.IsNullOrEmpty(textoOcr))
                {
                    _hub.Publicar(new OCRMensaje
                    {
                        Sender = this,
                        TextoDetectado = textoOcr
                    });

                    _hub.Publicar(new ImagenBlobMensaje
                    {
                        Sender = this,
                        Imagen = Imagen
                    });
                }
            }
        }

        private void OnDescargaDetectada(DescargaDetectadaMensaje msg)
        {
            if (msg == null) return;

            var respuesta = _archivos.ProcesarDescarga(msg.NombreArchivo, msg.RutaTemp, msg.Extension);

            if (!respuesta.Ok)
            {
                _hub.Publicar(new NotificacionUIEvent(
                    this,
                    respuesta.Error.Mensaje ?? "Error al procesar archivo",
                    TipoNotificacion.Error
                ));
                return;
            }

            if (msg.Extension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
            {
                string rutaFinal = Path.Combine(
                    @"C:\comprobante",
                    msg.NombreArchivo,
                    msg.NombreArchivo + ".xml");

                var info = _xml.ExtraerInfoCFDI(rutaFinal);

                if (info.UUID != null && info.Fecha != null)
                {
                    _hub.Publicar(new CFDIMensaje
                    {
                        Sender = this,
                        UUID = info.UUID,
                        Fecha = info.Fecha
                    });
                }
            }


            _hub.Publicar(new NotificacionUIEvent(
                this,
                "Archivo procesado correctamente",
                TipoNotificacion.Info
            ));
        }

        private async void OnSolicitarCompletar(SolicitarCompletarCapturaMensaje msg)
        {
            if (!await _auth.AsegurarSesionValidaAsync())
            {
                _hub.Publicar(new NotificacionUIEvent(this, "Refresco de Autorización.", TipoNotificacion.Info));

                return;
            }

            _hub.Publicar(new MostrarCompletarCapturaDialogMensaje
            {
                Sender = this
            });
        }

        public async Task CompletarCapturaAsync(CompletarCapturaPagina datos, List<string> archivos)
        {
            await _blob.SubirArchivosBlob(_pagina,archivos);

            var r = await _api.CompletarPagina(datos);

            if (!r.Ok)
            {
                _hub.Publicar(new NotificacionUIEvent(
                    this,
                    "Error al completar la captura",
                    TipoNotificacion.Error));
            }
            else
            {
                _hub.Publicar(new NotificacionUIEvent(
                    this,
                    "Captura finalizada correctamente",
                    TipoNotificacion.Info));
            }
        }
    }
}
