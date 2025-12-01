using ContabeeApi.Modelos.Captura;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabeeCaptura
{
    /// <summary>
    /// Aquir irán todas las definiciones para el proceso de captura.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// REgersa la licencia de gdpicture.
        /// </summary>
        /// <returns></returns>
        private string GetGDlic()
        {
            return ContabeeComunes.Constantes.GDPARAM.Replace("A", "4");
        }

        /// <summary>
        /// Muestra la informacion de la Pagina.
        /// </summary>
        /// <param name="pagina"></param>
        private void ProcesaInicioTrabajo(PaginaTrabajoCapturaCloud pagina)
        {
            labelBoxRfc.Informacion = pagina.Rfc;
            labelBoxPago.Informacion = pagina.FormaPago;
            labelBoxUso.Informacion = pagina.UsoFactura;
            labelBoxCP.Informacion = pagina.CodigoPostal;
            labelBoxTarjeta.Informacion = pagina.TerminacionPago;
            labelBoxNombre.Informacion = pagina.Denominacion;
            labelBoxDireccion.Informacion = pagina.Direccion;
        }

        /// <summary>
        /// Realiza el refresco de token de ser necesario.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> EjecutarSiNecesarioAsync()
        {
            if (_servicioSesion.IsAuthenticated && !_servicioSesion.NeedsRefresh())
                return true;

            if (string.IsNullOrEmpty(_servicioSesion.ObtenerInfoAccesso().refresh_token))
            {
                _servicioSesion.Clear();
                return false;
            }

            await _refreshLock.WaitAsync();

            try
            {
                if (!_servicioSesion.NeedsRefresh())
                    return true;

                var respuesta = await _apiContabee.RefreshToken(_servicioSesion.ObtenerInfoAccesso().refresh_token);

                if (!respuesta.Ok)
                {
                    _servicioSesion.Clear();
                    return false;
                }
                _servicioSesion.EstablecerSesion(_servicioSesion.ObtenerNombreUsuario(), respuesta.Payload);
                return true;
            }
            finally
            {
                _refreshLock.Release();
            }
        }

    }
}
