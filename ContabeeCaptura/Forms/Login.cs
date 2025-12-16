using System;
using ContabeeComunes;
using System.Windows.Forms;
using ContabeeApi;
using ContabeeCaptura.Extensiones;
using ContabeeComunes.Sesion;
using TinyMessenger;
using ContabeeComunes.Fachada;

namespace ContabeeCaptura.Forms
{
    public partial class Login : Form
    {
        private readonly IApiContabee _apiContabee;
        private readonly IServicioSesion _servicioSesion;
        private readonly ITinyMessengerHub _hub;
        public Login(IApiContabee apiContabee, IServicioSesion servicioSesion, ITinyMessengerHub hub)
        {
            InitializeComponent();
            _apiContabee = apiContabee;
            _servicioSesion = servicioSesion;
            _hub = hub;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.labelError.MensajeEnLabel($"Contabee Capture V{Constantes.APPVERSION}", TipoNotificacion.Neutra);    
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            this.btnLogin.Enabled = false;
            var respuesta = await _apiContabee.Login(txtUser.Text, txtPass.Text);
            if (respuesta.Ok)
            {
                _servicioSesion.EstablecerSesion(txtUser.Text, respuesta.Payload);    
                this.Hide();
                var form1 = Program.ServiceProvider.GetService(typeof(ContabeeCaptura.Form1)) as ContabeeCaptura.Form1;
                form1.Show(); 
                // No cerrar la forma Login, mantiene la referencia a la app.
            }
            else
            {
                labelError.MensajeEnLabel("Usuario o contraseña incorrectos.", TipoNotificacion.Error);

                this.btnLogin.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _hub.Publish(new MensajeEjemplo
            {
                Dato = $"{DateTime.Now.ToLongTimeString()} Este es un mensaje de prueba desde el formulario de login. ",
                Sender = this
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _hub.Publish(new ContabeeCaptura.Fachada.MensajeClear
            {
                Sender = this
            });
        }
    }
}
