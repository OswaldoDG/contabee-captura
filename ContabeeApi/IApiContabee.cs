using ContabeeApi.Modelos.Captura;
using ContabeeComunes.RespuestaApi;
using ContabeeComunes.Seguridad;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ContabeeApi
{
    /// <summary>
    /// declaracion de los servicios del api contabee.
    /// </summary>
    public interface IApiContabee
    {
        /// <summary>
        /// Inicio de sesión.
        /// </summary>
        /// <param name="usuario">Email de la cuenta registrada.</param>
        /// <param name="contrasena">Contraseña de la cuenta registrada.</param>
        /// <returns>Retorno de operación.</returns>
        Task<RespuestaPayload<InfoAccesso>> Login(string usuario, string contrasena);
        /// <summary>
        /// Refresca el token de acceso de la cuenta en sesión.
        /// </summary>
        /// <param name="refreshToken">Token de refresco. </param>
        /// <returns>Retorno de Operación</returns>
        Task<RespuestaPayload<InfoAccesso>> RefreshToken(string refreshToken);
        /// <summary>
        /// Obtiene una página de trabajo para el visualizador de la UI.
        /// </summary>
        /// <returns>Retorno de operación.</returns>
        Task<RespuestaPayload<PaginaTrabajoCapturaCloud>> ObtienePagina();

        /// <summary>
        /// Finaliza la captura de la pagina.
        /// </summary>
        /// <param name="id">Id de la pagina.</param>
        /// <param name="pagina">Metadatos de la pagina.</param>
        /// <param name="files">Lista de los comprobantes.</param>
        /// <returns>Retorno de operacion.</returns>
        Task<Respuesta> CompletarPagina(long id, CompletarCapturaPagina pagina);

        Task<RespuestaPayload<string>> ComputerVision(Stream stream);

    }
}
