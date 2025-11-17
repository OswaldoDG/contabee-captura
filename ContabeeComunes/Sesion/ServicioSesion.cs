using ContabeeComunes.Seguridad;

namespace ContabeeComunes.Sesion
{
    public class ServicioSesion : IServicioSesion
    {
        string UserName = string.Empty;
        InfoAccesso InfoAccesso = null;

        public void EstablecerSesion(string userName, InfoAccesso infoAccesso)
        {
            this.UserName = userName;  
            this.InfoAccesso = infoAccesso;
        }

        public InfoAccesso ObtenerInfoAccesso()
        {
            return InfoAccesso;
        }

        public string ObtenerNombreUsuario()
        {
            return UserName;    
        }
    }
}
