using ContabeeComunes.RespuestaApi;
using System.Threading.Tasks;

namespace ContabeeComunes.ProxyGenerico
{
    public enum VerboHttp
    {
        POST = 0,
        GET = 1,
        DELETE = 2,
        PUT = 3,
    }

    public interface IProxyGenerico
    {
        Task<Respuesta> JsonPost(string nombreHostServicio, string endpoint, string descripcionOperacion, object payload);
        Task<RespuestaPayloadJson> JsonRespuestaSerializada(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, object payload);
        Task<Respuesta> JsonRespuesta(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, object payload);
    }
}
