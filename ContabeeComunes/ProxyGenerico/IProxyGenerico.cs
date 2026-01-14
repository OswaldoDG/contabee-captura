using ContabeeComunes.RespuestaApi;
using ContabeeComunes.Seguridad;
using ContabeeComunes.Sesion;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContabeeComunes.ProxyGenerico
{
    /// <summary>
    /// Verbos Http disponibles para el proxy genérico.
    /// </summary>
    public enum VerboHttp
    {
        POST = 0,
        GET = 1,
        DELETE = 2,
        PUT = 3,
    }

    /// <summary>
    /// Define un proxy de http genérico para los llamados a la API.
    /// </summary>
    public interface IProxyGenerico
    {
        Task<Respuesta> JsonPost(string nombreHostServicio, string endpoint, string descripcionOperacion, object payload);
        Task<RespuestaPayloadJson> JsonRespuestaSerializada(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, object payload);
        Task<Respuesta> JsonRespuesta(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, object payload);
        Task<RespuestaPayloadJson> JsonFormUrlEncodedContent(string nombreHostServicio, string endpoint, string descripcionOperaion, VerboHttp verbo, FormUrlEncodedContent form);
    }
}
