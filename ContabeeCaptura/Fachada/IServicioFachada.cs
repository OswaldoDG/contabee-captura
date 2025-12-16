using ContabeeApi.Modelos.Captura;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabeeCaptura.Fachada
{
    public interface IServicioFachada
    {
        Task SiguienteTrabajoAsync();
        Task CompletarCapturaAsync(CompletarCapturaPagina datos, List<string> archivos);
    }
}
