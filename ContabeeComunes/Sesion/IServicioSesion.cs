using ContabeeComunes.Seguridad;

namespace ContabeeComunes.Sesion
{
    public interface IServicioSesion
    {
        void EstablecerSesion(string userName, InfoAccesso infoAccesso);
        string ObtenerNombreUsuario();
        InfoAccesso ObtenerInfoAccesso();   
    }
}
