using ContabeeApi.Modelos.Captura;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabeeCaptura.Fachada
{
    public interface IServicioFachada
    {
        Task<bool> SiguienteTrabajoAsync();

        Task<bool> DescargaProcesamientoXML(string RutaTemp, string NombreArchivo, string Extension);

        Task<bool> SubirArchivosAsync(List<string> comprobantes);

        Task<bool> CompletarCapturaAsync(CompletarCapturaPagina completar);
    }
}
