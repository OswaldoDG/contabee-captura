using ContabeeApi.Modelos.Captura;
using ContabeeCaptura.Forms;
using ContabeeComunes;
using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabeeCaptura
{
    /// <summary>
    /// Aquir irán todas las definiciones para el proceso de captura.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// REgersa la licencia de gdpicture.
        /// </summary>
        /// <returns></returns>
        private string GetGDlic()
        {
            return ContabeeComunes.Constantes.GDPARAM.Replace("A", "4");
        }

        /// <summary>
        /// Lee el stream del comprobante.
        /// </summary>
        /// <param name="input">Stream del comprobante</param>
        /// <returns>Retorno de operación.</returns>
        private async Task<byte[]> ReadStreamFully(Stream input)
        {
            using (var ms = new MemoryStream())
            {
                await input.CopyToAsync(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Descarga el comprobante.
        /// </summary>
        /// <param name="tokenSAS">La cadena de tokenSAS para descargar el comprobante.</param>
        /// <returns>Retorno de operación.</returns>
        private async Task DescargaBlob(string tokenSAS)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(_pagina.TokenSas);

            if (!response.IsSuccessStatusCode)
            {
                _hubEventos.PublicarNotificacionUI(this, "Ocurrió un problema al bajar el archivo de la nube", TipoNotificacion.Error);
            }

            await MostrarImage(response);
        }

        /// <summary>
        /// Muestra la informacion de la Pagina.
        /// </summary>
        /// <param name="pagina"></param>
        private void ProcesaInicioTrabajo(PaginaTrabajoCapturaCloud pagina)
        {
            labelBoxRfc.Informacion = pagina.Rfc;
            labelBoxPago.Informacion = pagina.FormaPago;
            labelBoxUso.Informacion = pagina.UsoFactura;
            labelBoxCP.Informacion = pagina.CodigoPostal;
            labelBoxTarjeta.Informacion = pagina.TerminacionPago;
            labelBoxNombre.Informacion = pagina.Denominacion;
            labelBoxDireccion.Informacion = pagina.Direccion;
        }

        /// <summary>
        /// Visualiza la Imagen con los datos y OCR.
        /// </summary>
        /// <param name="response">Respuesta de la petición del blob.</param>
        /// <returns>Retorno de operación.</returns>
        private async Task MostrarImage(HttpResponseMessage response)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                byte[] bytes = await ReadStreamFully(responseStream);

                using (var msOcr = new MemoryStream(bytes))
                {
                    var ocrResultado = await _apiContabee.ComputerVision(msOcr);
                    txtBoxOCR.Text = ocrResultado?.Payload;
                }

                if (!string.IsNullOrEmpty(txtBoxOCR.Text))
                {
                    ProcesaInicioTrabajo(_pagina);

                    using (var msImagen = new MemoryStream(bytes))
                    {
                        visorImagenes.DisplayFromStream(msImagen);
                        visorImagenes.Visible = true;
                        visorImagenes.Focus();
                    }
                }
            }
        }


        private async Task SubirArchivosBlob(CompletarCaptura captura)
        {

            if (captura.comprobantesPath != null && captura.comprobantesPath.Count > 0)
            {
                using (var http = new HttpClient())
                {
                    foreach (var archivoLocal in captura.comprobantesPath)
                    {
                        var nombreArchivo = Path.GetFileName(archivoLocal);
                        var uri = new Uri(_pagina.TokenSas);
                        var segmentos = uri.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        string urlBlob = $"{uri.Scheme}://{uri.Host}/{segmentos[0]}/{_pagina.LoteId}/{nombreArchivo}?{uri.Query.TrimStart('?')}";


                        using (var fs = new FileStream(archivoLocal, FileMode.Open, FileAccess.Read))
                        {
                            var content = new StreamContent(fs);
                            content.Headers.Add("x-ms-blob-type", "BlockBlob");

                            var response = await http.PutAsync(urlBlob, content);
                            if (!response.IsSuccessStatusCode)
                            {
                                _hubEventos.PublicarNotificacionUI(this, $"Error al subir {archivoLocal}.", TipoNotificacion.Error);
                            }
                        }
                    }
                }

                _hubEventos.PublicarNotificacionUI(this, $"Archivos subidos correctamente.", TipoNotificacion.Info);
            }
        }

        /// <summary>
        /// Realiza el refresco de token de ser necesario.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> EjecutarSiNecesarioAsync()
        {
            if (_servicioSesion.IsAuthenticated && !_servicioSesion.NeedsRefresh())
                return true;

            if (string.IsNullOrEmpty(_servicioSesion.ObtenerInfoAccesso().refresh_token))
            {
                _servicioSesion.Clear();
                return false;
            }

            await _refreshLock.WaitAsync();

            try
            {
                if (!_servicioSesion.NeedsRefresh())
                    return true;

                var respuesta = await _apiContabee.RefreshToken(_servicioSesion.ObtenerInfoAccesso().refresh_token);

                if (!respuesta.Ok)
                {
                    _servicioSesion.Clear();
                    return false;
                }
                _servicioSesion.EstablecerSesion(_servicioSesion.ObtenerNombreUsuario(), respuesta.Payload);
                return true;
            }
            finally
            {
                _refreshLock.Release();
            }
        }


    }
}
