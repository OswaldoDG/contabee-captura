using ContabeeComunes.Configuracion;
using ContabeeComunes.RespuestaApi;
using ContabeeComunes.Seguridad;
using ContabeeComunes.Sesion;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace ContabeeComunes.ProxyGenerico
{
    public class ProxyGenerico : IProxyGenerico
    {
        public const string HOSTIDENTITY = "identidad";
        public const string HOSTTRANSCRIPT = "transcript";


        private readonly ApiConfig _apiConfig;
        private readonly ILogger<ProxyGenerico> logger;
        private readonly HttpClient httpClient;
        private readonly IServicioSesion _servicioSesion;

        public ProxyGenerico(IOptions<ApiConfig> options, ILogger<ProxyGenerico> logger, HttpClient httpClient, IServicioSesion servicioSesion)
        {
            _apiConfig = options.Value;
            this.logger = logger;
            this.httpClient = httpClient;
            _servicioSesion = servicioSesion;
        }

        public Task<Respuesta> JsonPost(string nombreHostServicio, string endpoint, string descripcionOperacion, object payload)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> JsonRespuesta(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, object payload)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaPayloadJson> JsonRespuestaSerializada(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, object payload)
        {
            RespuestaPayloadJson respuesta = new RespuestaPayloadJson();
            try
            {
                var (host, error) = ConfiguraApi(nombreHostServicio);
                if (error != null)
                {
                    respuesta.Error = error;
                }
                logger.LogDebug($"ProxyGenerico - JsonRespuestaSerializada {descripcionOperacion}");
                endpoint = $"/{endpoint.TrimStart('/')}";

                logger.LogDebug($"ProxyGenericoInterservicio - JsonRespuestaSerializada Llamado remoto a {httpClient.BaseAddress}/{endpoint}");

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _servicioSesion.ObtenerInfoAccesso().access_token);

                HttpResponseMessage response = null;
                var json = new JavaScriptSerializer();
                StringContent contenido = payload != null ? new StringContent(json.Serialize(payload), Encoding.UTF8, "application/json") : null;
                switch (verbo)
                {
                    case VerboHttp.POST:
                        response = await httpClient.PostAsync(host.TrimEnd('/') + endpoint, contenido);
                        break;


                    case VerboHttp.PUT:
                        response = await httpClient.PutAsync(host.TrimEnd('/') + endpoint, contenido);
                        break;

                    case VerboHttp.DELETE:
                        response = await httpClient.DeleteAsync(host.TrimEnd('/') + endpoint);
                        break;

                    case VerboHttp.GET:
                        response = await httpClient.GetAsync(host.TrimEnd('/') + endpoint);
                        break;
                }

                logger.LogDebug("ProxyGenericoInterservicio - JsonRespuestaSerializada Respuesta {Code} {Reason}", response.StatusCode, response.ReasonPhrase);
                string contenidoRespuesta = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    respuesta.Payload = contenidoRespuesta;
                }
                else
                {
                    respuesta.Error = new ErrorProceso() { Mensaje = $"ProxyGenericoInterservicio - JsonRespuestaSerializada error llamada remota {response.ReasonPhrase} {contenidoRespuesta}", Codigo = "", HttpCode = response.StatusCode };
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "ProxyGenericoInterservicio - JsonRespuestaSerializada Error en {Servicio} {Operacion} {Mensaje}", nombreHostServicio, descripcionOperacion, ex.Message);
                respuesta.Error = new ErrorProceso() { Mensaje = $"{ex.Message}", Codigo = "", HttpCode = HttpStatusCode.InternalServerError };
            }

            return respuesta;
        }

        public async Task<RespuestaPayloadJson> JsonFormUrlEncodedContent(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, FormUrlEncodedContent form)
        {
            RespuestaPayloadJson respuesta = new RespuestaPayloadJson();

            try
            {
                logger.LogDebug($"ProxyGenericoInterservicio - JsonFormUrlEncodedContent");
                var (host, error) = ConfiguraApi(nombreHostServicio);
                if (error != null)
                {
                    respuesta.Error = error;
                }
                else
                {
                    endpoint = $"/{endpoint.TrimStart('/')}";
                    httpClient.BaseAddress = new Uri(host.TrimEnd('/'));
                    var response = await httpClient.PostAsync(endpoint, form);
                    response.EnsureSuccessStatusCode();

                    string contenidoRespuesta = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        respuesta.Payload = contenidoRespuesta;
                        respuesta.Ok = true;
                    }
                    else
                    {
                        respuesta.Error = new ErrorProceso() { Mensaje = $"ProxyGenerico - JsonFormUrlEncodedContent error llamada remota {response.ReasonPhrase} {contenidoRespuesta}", Codigo = "", HttpCode = response.StatusCode };
                    }
                }
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, "ProxyGenerico - JsonFormUrlEncodedContent {Servicio} {Operacion} {Mensaje}", nombreHostServicio, descripcionOperacion, ex.Message);
            }
            return respuesta;
        }

        public Task<RespuestaPayloadJson> RefreshTokenJson(string nombreHostServicio, string endpoint, string descripcionOperaicon, VerboHttp verbo, string refresh)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica la condiguraion interservicio.
        /// </summary>
        /// <param name="nombreHostServicio">Nombr del servicio buscado.</param>
        /// <returns>Configuracion y error.</returns>
        private (string host, ErrorProceso error) ConfiguraApi(string nombreHostServicio)
        {
            switch (nombreHostServicio.ToLower())
            {
                case HOSTIDENTITY:
                    return (_apiConfig.UriIdentidad, null);
                case HOSTTRANSCRIPT:
                    return (_apiConfig.UriTranscript, null);
                default:
                    return (string.Empty, new ErrorProceso() { Mensaje = $"ProxyGenericoInterservicio - ConfiguraApi no existe configuracion para {nombreHostServicio}", Codigo = "", HttpCode = HttpStatusCode.MethodNotAllowed });
            }
        }

        //    public async Task<Respuesta> JsonPost(string nombreHostServicio, string endpoint, string descripcionOperacion, object? payload)
        //    {
        //        Respuesta respuesta = new Respuesta();
        //        try
        //        {
        //            logger.LogDebug($"ProxyGenericoInterservicio - JsonPost {descripcionOperacion}");
        //            var (host, error) = ConfiguraApi(nombreHostServicio);
        //            if (error != null)
        //            {
        //                respuesta.Error = error;
        //            }

        //            endpoint = $"/{endpoint.TrimStart('/')}";
        //            httpClient.BaseAddress = new Uri(host.TrimEnd('/'));

        //            TokenJWT? jWT = await servicioAuthJWT!.TokenInterproceso(host.ClaveAutenticacion!);
        //            if (jWT == null)
        //            {
        //                logger.LogDebug($"ProxyGenericoInterservicio - JsonPost Error al obtener el token interservicio de JWT para {descripcionOperacion}");
        //                respuesta.Error = new ErrorProceso() { Mensaje = $"ProxyGenericoInterservicio - no fue posible obtener JWT", Codigo = "", HttpCode = HttpStatusCode.UnprocessableEntity };
        //            }
        //            else
        //            {
        //                logger.LogDebug($"ProxyGenericoInterservicio - JsonPost Llamado remoto a {httpClient.BaseAddress}/{endpoint}");
        //                string? jsonContent = null;
        //                if (payload != null)
        //                {
        //                    jsonContent = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
        //                    {
        //                        ContractResolver = new CamelCasePropertyNamesContractResolver()
        //                    });
        //                }

        //                StringContent? contenido = jsonContent != null ? new StringContent(jsonContent, Encoding.UTF8, "application/json") : null;
        //                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jWT.access_token);
        //                var response = await httpClient.PostAsync(endpoint, contenido);

        //                logger.LogDebug("ProxyGenericoInterservicio - JsonPost Respuesta {Code} {Reason}", response.StatusCode, response.ReasonPhrase);

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    respuesta.Ok = true;
        //                }
        //                else
        //                {
        //                    string? contenidoRespuesta = await response.Content.ReadAsStringAsync();
        //                    respuesta.Error = new ErrorProceso() { Mensaje = $"ProxyGenericoInterservicio - JsonPost error llamada remota {response.ReasonPhrase} {contenidoRespuesta}", Codigo = "", HttpCode = response.StatusCode };
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            logger.LogError(ex, "ProxyGenericoInterservicio - JsonPost Error en {Servicio} {Operacion} {Mensaje}", nombreHostServicio, descripcionOperacion, ex.Message);
        //            respuesta.Error = new ErrorProceso() { Mensaje = $"{ex.Message}", Codigo = "", HttpCode = HttpStatusCode.InternalServerError };
        //        }

        //        return respuesta;
        //    }

        //    public async Task<RespuestaPayloadJson> JsonRespuestaSerializada(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, object? payload)
        //    {
        //        RespuestaPayloadJson respuesta = new RespuestaPayloadJson();
        //        try
        //        {
        //            var (host, error) = await ConfiguraApi(nombreHostServicio);
        //            if (error != null)
        //            {
        //                respuesta.Error = error;
        //            }

        //            HttpClient httpClient = httpClientFactory.CreateClient(nombreHostServicio);
        //            logger.LogDebug($"ProxyGenericoInterservicio - JsonRespuestaSerializada {descripcionOperacion}");
        //            endpoint = $"/{endpoint.TrimStart('/')}";
        //            httpClient.BaseAddress = new Uri(host!.UrlBase.TrimEnd('/'));

        //            TokenJWT? jWT = await servicioAuthJWT!.TokenInterproceso(host.ClaveAutenticacion!);
        //            if (jWT == null)
        //            {
        //                logger.LogDebug($"ProxyGenericoInterservicio - JsonRespuestaSerializada Error al obtener el token interservicio de JWT para {descripcionOperacion}");
        //                respuesta.Error = new ErrorProceso() { Mensaje = $"ProxyGenericoInterservicio - no fue posible obtener JWT", Codigo = "", HttpCode = HttpStatusCode.UnprocessableEntity };
        //            }
        //            else
        //            {
        //                logger.LogDebug($"ProxyGenericoInterservicio - JsonRespuestaSerializada Llamado remoto a {httpClient.BaseAddress}/{endpoint}");

        //                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jWT.access_token);

        //                HttpResponseMessage? response = null;
        //                StringContent? contenido = payload != null ? new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json") : null;
        //                switch (verbo)
        //                {
        //                    case VerboHttp.POST:
        //                        response = await httpClient.PostAsync(endpoint, contenido);
        //                        break;


        //                    case VerboHttp.PUT:
        //                        response = await httpClient.PutAsync(endpoint, contenido);
        //                        break;

        //                    case VerboHttp.DELETE:
        //                        response = await httpClient.DeleteAsync(endpoint);
        //                        break;

        //                    case VerboHttp.GET:
        //                        response = await httpClient.GetAsync(endpoint);
        //                        break;
        //                }

        //                logger.LogDebug("ProxyGenericoInterservicio - JsonRespuestaSerializada Respuesta {Code} {Reason}", response.StatusCode, response.ReasonPhrase);
        //                string? contenidoRespuesta = await response.Content.ReadAsStringAsync();

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    respuesta.Payload = contenidoRespuesta;
        //                }
        //                else
        //                {
        //                    respuesta.Error = new ErrorProceso() { Mensaje = $"ProxyGenericoInterservicio - JsonRespuestaSerializada error llamada remota {response.ReasonPhrase} {contenidoRespuesta}", Codigo = "", HttpCode = response.StatusCode };
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            logger.LogError(ex, "ProxyGenericoInterservicio - JsonRespuestaSerializada Error en {Servicio} {Operacion} {Mensaje}", nombreHostServicio, descripcionOperacion, ex.Message);
        //            respuesta.Error = new ErrorProceso() { Mensaje = $"{ex.Message}", Codigo = "", HttpCode = HttpStatusCode.InternalServerError };
        //        }

        //        return respuesta;
        //    }

        //    public async Task<Respuesta> JsonRespuesta(string nombreHostServicio, string endpoint, string descripcionOperacion, VerboHttp verbo, object? payload)
        //    {
        //        Respuesta respuesta = new();
        //        try
        //        {
        //            var (host, error) = await ConfiguraApi(nombreHostServicio);
        //            if (error != null)
        //            {
        //                respuesta.Error = error;
        //            }

        //            HttpClient httpClient = httpClientFactory.CreateClient(nombreHostServicio);
        //            logger.LogDebug($"ProxyGenericoInterservicio - JsonRespuesta {descripcionOperacion}");
        //            endpoint = $"/{endpoint.TrimStart('/')}";
        //            httpClient.BaseAddress = new Uri(host!.UrlBase.TrimEnd('/'));

        //            TokenJWT? jWT = await servicioAuthJWT!.TokenInterproceso(host.ClaveAutenticacion!);
        //            if (jWT == null)
        //            {
        //                logger.LogDebug($"ProxyGenericoInterservicio - JsonRespuesta Error al obtener el token interservicio de JWT para {descripcionOperacion}");
        //                respuesta.Error = new ErrorProceso() { Mensaje = $"ProxyGenericoInterservicio - no fue posible obtener JWT", Codigo = "", HttpCode = HttpStatusCode.UnprocessableEntity };
        //            }
        //            else
        //            {
        //                logger.LogDebug($"ProxyGenericoInterservicio - JsonRespuesta Llamado remoto a {httpClient.BaseAddress}/{endpoint}");

        //                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jWT.access_token);

        //                HttpResponseMessage? response = null;
        //                StringContent? contenido = payload != null ? new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json") : null;
        //                switch (verbo)
        //                {
        //                    case VerboHttp.POST:
        //                        response = await httpClient.PostAsync(endpoint, contenido);
        //                        break;

        //                    case VerboHttp.PUT:
        //                        response = await httpClient.PutAsync(endpoint, contenido);
        //                        break;

        //                    case VerboHttp.DELETE:
        //                        response = await httpClient.DeleteAsync(endpoint);
        //                        break;

        //                    case VerboHttp.GET:
        //                        response = await httpClient.GetAsync(endpoint);
        //                        break;
        //                }

        //                logger.LogDebug("ProxyGenericoInterservicio - JsonRespuesta Respuesta {Code} {Reason}", response.StatusCode, response.ReasonPhrase);

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    respuesta.Ok = true;
        //                }
        //                else
        //                {
        //                    respuesta.Error = new ErrorProceso() { Mensaje = $"ProxyGenericoInterservicio - JsonRespuesta error llamada remota {response.ReasonPhrase}", Codigo = "", HttpCode = response.StatusCode };
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            logger.LogError(ex, "ProxyGenericoInterservicio - JsonRespuesta Error en {Servicio} {Operacion} {Mensaje}", nombreHostServicio, descripcionOperacion, ex.Message);
        //            respuesta.Error = new ErrorProceso() { Mensaje = $"{ex.Message}", Codigo = "", HttpCode = HttpStatusCode.InternalServerError };
        //        }

        //        return respuesta;
        //    }

        //}

    }

}
