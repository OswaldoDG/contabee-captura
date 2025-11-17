using Microsoft.Extensions.Logging;
using System;
using TinyMessenger;

namespace ContabeeComunes.Eventos
{
    public class HubEventos: IHubEventos
    {
        private readonly ILogger _logger;
        private readonly ITinyMessengerHub _hub;
        public HubEventos(ILogger<HubEventos> logger, ITinyMessengerHub hub)
        {
            _logger = logger;
            _hub = hub;
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
    }
}
