using ContabeeComunes.RespuestaApi;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ContabeeApi.Archivos
{
    public class ServicioArchivos : IServicioArchivos
    {
        private readonly ILogger<ServicioArchivos> _logger;

        public ServicioArchivos(ILogger<ServicioArchivos> logger)
        {
            _logger = logger;
        }

        public RespuestaPayload<string> ProcesarDescarga(string nombreBlob, string rutaTemp, string extension)
        {
            var respuesta = new RespuestaPayload<string> { Ok = false };
            var blob = Path.GetFileNameWithoutExtension(nombreBlob);
            string carpetaDestino = @"C:\comprobante";
            string carpetaBlob = Path.Combine(carpetaDestino, blob);
            int contador = 1;
            try
            {
                if (!Directory.Exists(carpetaBlob))
                    Directory.CreateDirectory(carpetaBlob);

                if (extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    string nuevoNombre = blob;
                    nuevoNombre += $"_{contador++}";
                    string rutaFinal = Path.Combine(carpetaBlob, nuevoNombre + extension);

                    if (File.Exists(rutaFinal))
                        File.Delete(rutaFinal);

                    File.Copy(rutaTemp, rutaFinal);
                    File.Delete(rutaTemp);
                    if (extension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
                        respuesta.Payload = rutaFinal;
                    respuesta.Ok = true;
                }
                else if (extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(rutaTemp, carpetaBlob);
                    File.Delete(rutaTemp);

                    var archivos = Directory.GetFiles(carpetaBlob, "*.*", SearchOption.AllDirectories);

                    foreach (var archivo in archivos)
                    {
                        string ext = Path.GetExtension(archivo);
                        string rutaDirectorio = Path.GetDirectoryName(archivo);

                        string nuevoNombre = blob;

                        if (archivos.Length > 1)
                            nuevoNombre += $"_{contador++}";

                        nuevoNombre += ext;

                        string rutaDestino = Path.Combine(rutaDirectorio, nuevoNombre);

                        if (!archivo.Equals(rutaDestino, StringComparison.OrdinalIgnoreCase))
                        {
                            if (File.Exists(rutaDestino))
                                File.Delete(rutaDestino);

                            File.Move(archivo, rutaDestino);
                            if (ext.Equals(".xml", StringComparison.OrdinalIgnoreCase))
                                respuesta.Payload = rutaDestino;
                        }
                    }

                    respuesta.Ok = true;
                }
                else
                {
                    respuesta.Error = new ErrorProceso
                    {
                        Mensaje = $"Extensión no soportada: {extension}"
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "ServicioArchivos - ProcesarDescarga: Excepción al procesar la descarga");

                respuesta.Error = new ErrorProceso
                {
                    Mensaje = ex.Message
                };
            }

            return respuesta;
        }
    }
}
