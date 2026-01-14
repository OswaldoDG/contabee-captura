using ContabeeComunes.RespuestaApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.Vision
{
    public interface IServicioVision
    {
        /// <summary>
        /// Realiza el OCR de la imagen recibida en stream.
        /// </summary>
        /// <param name="imagen">Stream de la image.</param>
        /// <returns>Retorno de operación.</returns>
        Task<RespuestaPayload<string>> TextoOCR(Stream imagen);
    }
}
