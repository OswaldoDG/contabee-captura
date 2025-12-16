using ContabeeComunes.RespuestaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.Archivos
{
    /// <summary>
    /// Definiciones de los archivos que serán descargados desde el navegador.
    /// </summary>
    public interface IServicioArchivos
    {
        /// <summary>
        /// Almacena el archivo localmente.
        /// </summary>
        Respuesta ProcesarDescarga(string nombreBlob, string rutaTemp, string extension);
    }
}
