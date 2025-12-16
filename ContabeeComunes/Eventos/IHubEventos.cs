using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger;

namespace ContabeeComunes.Eventos
{
    public interface IHubEventos
    {
        void PublicarNotificacionUI(object sender, string mensaje, TipoNotificacion tipo);

        void Publicar<T>(T mensaje) where T : class, ITinyMessage;

        Guid Suscribir<T>(Action<T> accion) where T : class, ITinyMessage;

        void Desuscribir(Guid idSuscripcion);
    }
}
