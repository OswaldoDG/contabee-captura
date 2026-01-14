using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TinyMessenger;

namespace ContabeeComunes.Eventos
{
    public class HubEventos: IHubEventos
    {
        private readonly ILogger _logger;
        private readonly ITinyMessengerHub _hub;
        private readonly Dictionary<Guid, Action> _desuscriptores;
        public HubEventos(ILogger<HubEventos> logger, ITinyMessengerHub hub)
        {
            _logger = logger;
            _hub = hub;
            _desuscriptores = new Dictionary<Guid, Action>();
        }

        public void PublicarNotificacionUI(object sender, string mensaje, TipoNotificacion tipo)
        {
            try
            {
                var evento = new NotificacionUIEvent(sender, mensaje, tipo);
                _hub.Publish(evento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al publicar NotificacionUIEvent: {Mensaje}", ex.Message);
            }
        }

        public void Publicar<T>(T mensaje) where T : class, ITinyMessage
        {
            _hub.PublishAsync(mensaje);
        }

        public Guid Suscribir<T>(Action<T> accion) where T : class, ITinyMessage
        {
            var token = _hub.Subscribe<T>(accion);

            var id = Guid.NewGuid();

            Action desuscribir = () =>
            {
                _hub.Unsubscribe<T>(token);
            };

            lock (_desuscriptores)
            {
                _desuscriptores.Add(id, desuscribir);
            }

            return id;
        }

        public void Desuscribir(Guid idSuscripcion)
        {
            lock (_desuscriptores)
            {
                if (_desuscriptores.ContainsKey(idSuscripcion))
                {
                    var accionDesuscribir = _desuscriptores[idSuscripcion];

                    accionDesuscribir.Invoke();

                    _desuscriptores.Remove(idSuscripcion);
                }
            }
        }
    }
}
