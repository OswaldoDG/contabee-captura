
using TinyMessenger;

namespace ContabeeComunes.Eventos
{
    public class NotificacionUIEvent : ITinyMessage
    {
        public object Sender { get; }
        public string Mensaje { get; }

        public TipoNotificacion Tipo { get; }

        public NotificacionUIEvent(object sender, string mensaje, TipoNotificacion tipo)
        {
            Sender = sender;
            Mensaje = mensaje;
            Tipo = tipo;    
        }

    }
}
