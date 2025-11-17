using ContabeeComunes.RespuestaApi;
using ContabeeComunes.Seguridad;
using System.Threading.Tasks;

namespace ContabeeApi
{
    /// <summary>
    /// declaracion de los servicios del api contabee.
    /// </summary>
    public interface IApiContabee
    {
        Task<RespuestaPayload<InfoAccesso>> Login(string usuario, string contrasena);   

    }
}
