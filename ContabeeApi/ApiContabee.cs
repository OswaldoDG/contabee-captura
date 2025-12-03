using ContabeeApi.Modelos.Captura;
using ContabeeComunes.Configuracion;
using ContabeeComunes.ProxyGenerico;
using ContabeeComunes.RespuestaApi;
using ContabeeComunes.Seguridad;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ContabeeApi
{
    public class ApiContabee: IApiContabee
    {
        readonly ApiConfig _config;
        readonly AzureConfig _azureConfig;
        readonly IProxyGenerico _proxyGenerico;
        readonly ILogger<ApiContabee> _logger;

        public ApiContabee(IOptions<ApiConfig> config, IOptions<AzureConfig> azureConfig, IProxyGenerico proxyGenerico, ILogger<ApiContabee> logger) 
        {
            _config = config.Value;
            _azureConfig = azureConfig.Value;
            _logger = logger;
            _proxyGenerico = proxyGenerico;
        }

        public async Task<RespuestaPayload<InfoAccesso>> Login(string usuario, string contrasena)
        {
            _logger.LogDebug("Inicando login");
            RespuestaPayload < InfoAccesso > respuesta = new RespuestaPayload<InfoAccesso>();
            try
            {
                var form = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("grant_type","password"),
                    new KeyValuePair<string,string>("client_id","contabee-password"),
                    new KeyValuePair<string,string>("username", usuario),
                    new KeyValuePair<string,string>("password", contrasena),
                    new KeyValuePair<string,string>("scope","offline_access")
                 });


                var proxy = await _proxyGenerico.JsonFormUrlEncodedContent("identidad", "/connect/token","Inicio Sesion", VerboHttp.POST, form);

                if (!proxy.Ok)
                {
                    _logger.LogError("ProxyGenerico - Login: {Error}", proxy.Error?.Mensaje ?? "Error desconocido al hacer login.");
                    
                    respuesta.Error = proxy.Error;
                    respuesta.HttpCode = proxy.HttpCode;
                    return respuesta;
                }

                respuesta.Payload = JsonSerializer.Deserialize<InfoAccesso>(proxy.Payload);
                respuesta.Ok = true;

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Exepción al hacer Login");
                respuesta.Error = new ErrorProceso()
                {
                    Mensaje = ex.Message
                };
            }

            return respuesta;
        }

        public async Task<RespuestaPayload<InfoAccesso>> RefreshToken(string refreshToken)
        {
            _logger.LogDebug("Inicando login");
            RespuestaPayload<InfoAccesso> respuesta = new RespuestaPayload<InfoAccesso>();
            try
            {
                var form = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("grant_type","password"),
                    new KeyValuePair<string,string>("client_id","contabee-password"),
                    new KeyValuePair<string,string>("refresh_token", refreshToken)  
                });


                var proxy = await _proxyGenerico.JsonFormUrlEncodedContent("identidad", "/connect/token", "Inicio Sesion", VerboHttp.POST, form);

                if (!proxy.Ok)
                {
                    _logger.LogError("ProxyGenerico - Login: {Error}", proxy.Error?.Mensaje ?? "Error desconocido al hacer login.");

                    respuesta.Error = proxy.Error;
                    respuesta.HttpCode = proxy.HttpCode;
                    return respuesta;
                }

                respuesta.Payload = JsonSerializer.Deserialize<InfoAccesso>(proxy.Payload);
                respuesta.Ok = true;

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Exepción al hacer Login");
                respuesta.Error = new ErrorProceso()
                {
                    Mensaje = ex.Message
                };
            }

            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaTrabajoCapturaCloud>> ObtienePagina()
        {
            _logger.LogDebug("ObteniendoPagina");
            RespuestaPayload<PaginaTrabajoCapturaCloud> respuesta = new RespuestaPayload<PaginaTrabajoCapturaCloud>();
            try
            {
                var proxy = await _proxyGenerico.JsonRespuestaSerializada("transcript","/captura/pagina","Obteniendo Pagina", VerboHttp.GET, null);
                if (!proxy.Ok)
                {
                    _logger.LogError("ProxyGenerico - ObtienePagina", proxy.Error?.Mensaje ?? "Error desconocido al obtener página");

                    respuesta.Error = proxy.Error;
                    respuesta.HttpCode = proxy.HttpCode;
                    return respuesta;
                }
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                options.Converters.Add(new JsonStringEnumConverter());
                var pagina =  JsonSerializer.Deserialize<PaginaTrabajoCapturaCloud>(proxy.Payload, options);

                respuesta.Payload = pagina;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Excepción al obtener página");
                respuesta.Error = new ErrorProceso() 
                {
                    Mensaje = ex.Message
                };
            }
            return respuesta;
        }

        public async Task<Respuesta> CompletarPagina(CompletarCapturaPagina pagina)
        {
            _logger.LogDebug("CompletarPagina");
            Respuesta respuesta = new Respuesta();
            try
            {

                var proxy = await _proxyGenerico.JsonRespuestaSerializada("transcript", $"captura/pagina/completar", "CompletarPagina", VerboHttp.POST, pagina);
                if (!proxy.Ok)
                {
                    _logger.LogError("ProxyGenerico - CompletarPagina", proxy.Error?.Mensaje ?? "Error desconocido al Completar Pagina");

                    respuesta.Error = proxy.Error;
                    respuesta.HttpCode = proxy.HttpCode;
                    return respuesta;
                }

                respuesta.Ok = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al CompletarPagina");
                respuesta.Error = new ErrorProceso()
                {
                    Mensaje = ex.Message
                };
            }
            return respuesta;
        }

        public async Task<RespuestaPayload<string>> ComputerVision(Stream stream)
        {
            RespuestaPayload<string> r = new RespuestaPayload<string>();
            string endpoint = _azureConfig.Endpoint;
            string apiKey = _azureConfig.Key;

            var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(apiKey))
            { Endpoint = endpoint };

            if (stream.CanSeek)
                stream.Position = 0;

            var textHeaders = await client.ReadInStreamAsync(stream);
            string operationId = textHeaders.OperationLocation.Split('/').Last();

            ReadOperationResult resultado;
            do
            {
                await Task.Delay(500);
                resultado = await client.GetReadResultAsync(Guid.Parse(operationId));
            }
            while (resultado.Status == OperationStatusCodes.Running ||
                   resultado.Status == OperationStatusCodes.NotStarted);

            var builder = new StringBuilder();

            var pages = resultado.AnalyzeResult.ReadResults;
            foreach (var page in pages)
            {
                foreach (var line in page.Lines)
                    builder.AppendLine(line.Text);
            }


            var texto =  builder.ToString().Trim();
            r.Payload = texto;
            return r;
        }
    }
}
