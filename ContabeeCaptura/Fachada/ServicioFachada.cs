using ContabeeApi;
using ContabeeApi.Archivos;
using ContabeeApi.Auth;
using ContabeeApi.Blob;
using ContabeeApi.Modelos.Captura;
using ContabeeApi.Vision;
using ContabeeApi.XML;
using ContabeeComunes;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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

        private PaginaTrabajoCapturaCloud _pagina;

        public ServicioFachada(IApiContabee api, IHubEventos hub, IServicioBlob blob, IServicioVision vision, IServicioAuth auth, IServicioXML xml, IServicioArchivos archivos)
        {
            _api = api;
            _hub = hub;
            _vision = vision;
            _blob = blob;
            _auth = auth;
            _xml = xml;
            _archivos = archivos;
        }

        public async Task<bool> SiguienteTrabajoAsync()
        {
            _hub.Publicar(new NotificacionUIEvent(this, "Buscando nuevo trabajo espere por favor.", TipoNotificacion.Info));

            if (!await _auth.AsegurarSesionValidaAsync())
            {
                _hub.Publicar(new NotificacionUIEvent(this, "Refresco de Autorización.", TipoNotificacion.Info)); return false;
            }

            _hub.Publicar(new MensajeClear { Sender = this });

            var datos = await _api.ObtienePagina();

            if (!datos.Ok) { _hub.Publicar(new NotificacionUIEvent(this, datos.Error.Mensaje, TipoNotificacion.Info)); return false; }

            _pagina = datos.Payload;

            _hub.Publicar(new DatosFiscalesMensaje
            {
                Sender = this,
                Datos = datos.Payload
            });

            _hub.Publicar(new DesglosarIEPSMensaje 
            { 
                Sender = this,
                DesglosarIEPS = datos.Payload.DesglosarIEPS
            });

            _hub.Publicar(new NombreBlobMensaje 
            {
                Sender= this,
                NombreBlob = datos.Payload.Ruta
            });

            var bytesImagen = await _blob.DescargaImagenSaSAsync(datos.Payload.TokenSas);

            if (!bytesImagen.Ok)
            {
                _hub.Publicar(new NotificacionUIEvent(this, bytesImagen.Error.Mensaje, TipoNotificacion.Info)); return false;
            }

            byte[] Imagen = bytesImagen.Payload;

            if (Imagen == null && Imagen.Length == 0)
            {
                _hub.Publicar(new NotificacionUIEvent(this, "No hay datos para mostrar", TipoNotificacion.Info)); return false;
            }

            string textoOcr = string.Empty;

            using (var msOcr = new MemoryStream(Imagen))
            {
                var r = await _vision.TextoOCR(msOcr);

                if (!r.Ok) { _hub.Publicar(new NotificacionUIEvent(this, r.Error.Mensaje, TipoNotificacion.Info)); return false; }
                ;

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

            _hub.Publicar(new NotificacionUIEvent(this, "Trabajo encontrado puede continuar con la captura.", TipoNotificacion.Info));

            return true;
        }

        public async Task<bool> DescargaProcesamientoXML(string NombreArchivo, string RutaTemp, string Extension)
        {
            try
            {
                var respuesta = _archivos.ProcesarDescarga(NombreArchivo, RutaTemp, Extension);

                if (!respuesta.Ok) 
                {
                    _hub.Publicar(new NotificacionUIEvent(
                        this,
                        respuesta.Error.Mensaje ?? "Error al procesar archivo",
                        TipoNotificacion.Error
                    ));
                    return false;
                }

                var info = _xml.ExtraerInfoCFDI(respuesta.Payload);

                if (info.UUID != null && info.Fecha != null)
                {

                    DateTime? fechaCFDI = null;

                    if (DateTime.TryParse(info.Fecha, out DateTime temp))
                    {
                        fechaCFDI = temp;
                    }

                    _hub.Publicar(new CFDIMensaje
                    {
                        Sender = this,
                        UUID = info.UUID,
                        Fecha = fechaCFDI
                    });
                }
                _hub.Publicar(new NotificacionUIEvent(
                    this,
                    "Comprobantes descargados correctamente",
                    TipoNotificacion.Info
                ));


            }
            catch (Exception ex)
            {
                _hub.Publicar(new NotificacionUIEvent(
                this,
                ex.ToString(),
                TipoNotificacion.Info
                ));
            }

            return true;
        }

        public async Task<bool> SubirArchivosAsync(List<string> comprobantes)
        {
            try
            {
                var respuesta = await _blob.SubirArchivosBlob(_pagina, comprobantes);
                if (!respuesta.Ok)
                {
                    _hub.Publicar(new NotificacionUIEvent(
                        this,
                        respuesta.Error.Mensaje ?? "Error al procesar archivo",
                        TipoNotificacion.Error
                    ));
                    return false;
                }
            }
            catch (Exception ex)
            {
                _hub.Publicar(new NotificacionUIEvent(
                this,
                ex.ToString(),
                TipoNotificacion.Info
                ));
            }
            return true;
        }

        public async Task<bool> CompletarCapturaAsync(CompletarCapturaPagina completar)
        {
            try
            {
                completar.Id = _pagina.Id;
                var r = await _api.CompletarPagina(completar);

                if (!r.Ok)
                {
                    _hub.Publicar(new NotificacionUIEvent(
                        this,
                        $"Error al completar la captura: {r.Error.Mensaje}",
                        TipoNotificacion.Error));

                    return false;
                }

                _hub.Publicar(new NotificacionUIEvent(
                    this,
                    "Captura finalizada correctamente",
                    TipoNotificacion.Info));
            }
            catch (Exception ex)
            {
                _hub.Publicar(new NotificacionUIEvent(
                this,
                ex.ToString(),
                TipoNotificacion.Info
                ));
            }

            return true;
        }
    }
}
