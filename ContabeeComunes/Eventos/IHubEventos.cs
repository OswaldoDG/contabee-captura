using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeComunes.Eventos
{
    public interface IHubEventos
    {
        void PublicarNotificacionUI(object sender, string mensaje, TipoNotificacion tipo);
    }
}
