using ContabeeComunes.Seguridad;
using System;

namespace ContabeeComunes.Sesion
{
    public class ServicioSesion : IServicioSesion
    {
        string UserName = string.Empty;
        InfoAccesso InfoAccesso = null;
        public DateTime Expiration { get; private set; }

        public bool IsAuthenticated => !string.IsNullOrEmpty(InfoAccesso.access_token) && DateTime.UtcNow < Expiration;

        public void EstablecerSesion(string userName, InfoAccesso infoAccesso)
        {
            this.UserName = userName;  
            this.InfoAccesso = infoAccesso;
            Expiration = DateTime.UtcNow.AddSeconds(infoAccesso.expires_in - 60);
        }

        public InfoAccesso ObtenerInfoAccesso()
        {
            return InfoAccesso;
        }

        public string ObtenerNombreUsuario()
        {
            return UserName;    
        }
        public bool NeedsRefresh()
        {
            if (string.IsNullOrEmpty(InfoAccesso.refresh_token)) return false;
            return DateTime.UtcNow >= Expiration.AddMinutes(-5);
        }

        public void Clear()
        {
            InfoAccesso = null;
            Expiration = DateTime.MinValue;
        }
    }
}
