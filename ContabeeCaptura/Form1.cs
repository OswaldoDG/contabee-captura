using ContabeeCaptura.Extensiones;
using ContabeeComunes;
using ContabeeComunes.Eventos;
using ContabeeComunes.Sesion;
using System.Windows.Forms;
using TinyMessenger;

namespace ContabeeCaptura
{
    public partial class Form1 : Form
    {
        private readonly ServicioSesion _servicioSesion;
        private readonly IHubEventos _hubEventos;
        private readonly ITinyMessengerHub _hub;

        public Form1(IServicioSesion servicioSesion, ITinyMessengerHub hub ,IHubEventos hubEventos)
        {
            _servicioSesion = servicioSesion as ServicioSesion;
            _hubEventos = hubEventos;
            _hub = hub;
            InitializeComponent();
            SetupUI();
            
        }

        /// <summary>
        /// En este setup se configuran los elementos de la UI  
        /// </summary>
        private void SetupUI()
        {
            this.Text = $"Contabee Capture V{Constantes.APPVERSION} - {_servicioSesion.ObtenerNombreUsuario()}";
            this.statuLabel.Text = "ContabeeCapture V" + Constantes.APPVERSION;
            this.statuLabel.Image = global::ContabeeCaptura.Properties.Resources.alert_info_icon;
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// En este setup se configuran los hooks de eventos y servicios.
        /// </summary>
        private void SetupHooks()
        {
            _hub.Subscribe<NotificacionUIEvent>(evento =>
            {
                this.statuLabel.Mensaje(evento.Mensaje, evento.Tipo);
            });
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            SetupHooks();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _hubEventos.PublicarNotificacionUI(this, "Este es un mensaje de prueba", TipoNotificacion.Error);  
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
