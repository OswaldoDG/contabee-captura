using ContabeeComunes.Seguridad;

namespace ContabeeComunes.Sesion
{
    public interface IServicioSesion
    {
        bool EstablecerSesion(string userName, InfoAccesso infoAccesso);
        string ObtenerNombreUsuario();
        InfoAccesso ObtenerInfoAccesso();
        bool NeedsRefresh();
        void Clear();
    }
}
