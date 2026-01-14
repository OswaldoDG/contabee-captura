using ContabeeCaptura.Fachada;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using TinyMessenger;

namespace ContabeeCaptura.Controls
{
    public partial class ControlEjemplo : UserControl
    {
        private IHubEventos _hubEventos;
        private ITinyMessengerHub _hub;

        public ControlEjemplo()
        {
            InitializeComponent();
        }

        private void ControlEjemplo_Load(object sender, System.EventArgs e)
        {
            try
            {
                _hub = Program.ServiceProvider.GetService<ITinyMessengerHub>();
                _hubEventos = Program.ServiceProvider.GetService<IHubEventos>();
                CreaHooks();
            }
            catch (System.Exception)
            {

            }
            
        }

        private void CreaHooks()
        {
            try
            {
                _hub.Subscribe<MensajeEjemplo>(evento =>
                {
                    this.label1.Text = evento.Dato;
                });

                _hub.Subscribe<MensajeClear>(evento =>
                {
                    this.label1.Text = "";
                });
            }
            catch (System.Exception)
            {

            }
        }
    }
}
