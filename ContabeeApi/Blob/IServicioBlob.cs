using ContabeeApi.Modelos.Captura;
using ContabeeComunes.RespuestaApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.Blob
{
    /// <summary>
    /// Deficiones para las operaciones con los blobs carga y descarga.
    /// </summary>
    public interface IServicioBlob
    {
        /// <summary>
        /// Descarga de la imagen.
        /// </summary>
        /// <param name="TokenSaS">Cadena que contiene la dirección del blob para descargar.</param>
        /// <returns>Retorno de Operación.</returns>
        Task<RespuestaPayload<byte[]>> DescargaImagenSaSAsync(string TokenSaS);

        /// <summary>
        /// Carga los archivos al blob storage en azure
        /// </summary>
        /// <param name="datos">La información.</param>
        /// <param name="archivos">Lista de los archivos a subir al blob.</param>
        /// <returns>Retorno de operación.</returns>
        Task<Respuesta> SubirArchivosBlob(PaginaTrabajoCapturaCloud pagina, List<string> archivos);
    }
}
