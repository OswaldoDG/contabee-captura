using ContabeeComunes.Sesion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContabeeApi.Auth
{
    public class ServicioAuth : IServicioAuth
    {
        private readonly ServicioSesion _servicioSesion;
        private readonly IApiContabee _api;
        private readonly SemaphoreSlim _refreshLock = new SemaphoreSlim(1, 1);

        public ServicioAuth(IServicioSesion servicioSesion, IApiContabee api)
        {
            _servicioSesion = servicioSesion as ServicioSesion;
            _api = api;
        }

        public async Task<bool> AsegurarSesionValidaAsync()
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

                var respuesta = await _api.RefreshToken(
                    _servicioSesion.ObtenerInfoAccesso().refresh_token);

                if (!respuesta.Ok)
                {
                    _servicioSesion.Clear();
                    return false;
                }

                _servicioSesion.EstablecerSesion(
                    _servicioSesion.ObtenerNombreUsuario(),
                    respuesta.Payload);

                return true;
            }
            finally
            {
                _refreshLock.Release();
            }
        }
    }
}
