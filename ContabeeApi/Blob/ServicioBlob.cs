using ContabeeApi.Modelos.Captura;
using ContabeeComunes;
using ContabeeComunes.RespuestaApi;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContabeeApi.Blob
{
    public class ServicioBlob : IServicioBlob
    {
        private readonly ILogger<ServicioBlob> _logger;
        private readonly IHttpClientFactory _http;

        public ServicioBlob(ILogger<ServicioBlob> logger, IHttpClientFactory http)
        {
            _logger = logger;
            _http = http;
        }

        public async Task<RespuestaPayload<byte[]>> DescargaImagenSaSAsync(string TokenSaS)
        {
            RespuestaPayload<byte[]> respuesta = new RespuestaPayload<byte[]>();
            try
            {
                _logger.LogDebug("ServicioBlob - DescargaImagenSaSAsync");
                var client = _http.CreateClient();

                var response = await client.GetAsync(TokenSaS);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("ProxyGenerico - CompletarPagina", "Ocurrió un problema al bajar el archivo de la nube");
                    respuesta.Error = new ErrorProceso() 
                    { 
                        Mensaje = "No se pudo obtener el comprobante de la nube.",
                        HttpCode = response.StatusCode
                    };
                    respuesta.HttpCode = response.StatusCode;
                    return respuesta;
                }

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var ms = new System.IO.MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    respuesta.Payload = ms.ToArray();
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Excepción al DescargaImagenSaSAsync");
                respuesta.Error = new ErrorProceso()
                {
                    Mensaje = "Error al descargar la imagen del comprobante"
                };
            }
            return respuesta;
        }

        public async Task<Respuesta> SubirArchivosBlob(PaginaTrabajoCapturaCloud pagina, List<string> archivos)
        {
            Respuesta respuesta = new Respuesta();
            if (archivos != null && archivos.Count > 0)
            {
                using (var http = new HttpClient())
                {
                    foreach (var archivoLocal in archivos)
                    {
                        var nombreArchivo = Path.GetFileName(archivoLocal);
                        var uri = new Uri(pagina.TokenSas);
                        var segmentos = uri.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        string urlBlob = $"{uri.Scheme}://{uri.Host}/{segmentos[0]}/{pagina.LoteId}/{nombreArchivo}?{uri.Query.TrimStart('?')}";


                        using (var fs = new FileStream(archivoLocal, FileMode.Open, FileAccess.Read))
                        {
                            var content = new StreamContent(fs);
                            content.Headers.Add("x-ms-blob-type", "BlockBlob");

                            var response = await http.PutAsync(urlBlob, content);
                            if (!response.IsSuccessStatusCode)
                            {
                                _logger.LogError(response.Content.ToString(), "Excepción al SubirArchivosBlob");
                                respuesta.Error = new ErrorProceso()
                                {
                                    Mensaje = response.Content.ToString()
                                };
                                return respuesta;
                            }
                            respuesta.Ok = true;
                        }
                    }
                }

                _logger.LogDebug("Archivos subidos correctamente");
            }
            return respuesta;
        }
    }
}
