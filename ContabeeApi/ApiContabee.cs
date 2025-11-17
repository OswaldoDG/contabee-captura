using ContabeeComunes.Configuracion;
using ContabeeComunes.ProxyGenerico;
using ContabeeComunes.RespuestaApi;
using ContabeeComunes.Seguridad;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ContabeeApi
{
    public class ApiContabee: IApiContabee
    {
        readonly ApiConfig _config;
        readonly IProxyGenerico _proxyGenerico;
        readonly ILogger<ApiContabee> _logger;

        public ApiContabee(IOptions<ApiConfig> config, IProxyGenerico proxyGenerico, ILogger<ApiContabee> logger) 
        {
            _config = config.Value;
            _logger = logger;
            _proxyGenerico = proxyGenerico;
        }

        public async Task<RespuestaPayload<InfoAccesso>> Login(string usuario, string contrasena)
        {
            _logger.LogDebug("Inicando login");
            RespuestaPayload < InfoAccesso > respuesta = new RespuestaPayload<InfoAccesso>();
            try
            {
                respuesta.Payload = new InfoAccesso()
                {
                    access_token = "demo"
                };
            }
            catch (System.Exception ex)
            {

            }

            return respuesta;
        }
    }
}
