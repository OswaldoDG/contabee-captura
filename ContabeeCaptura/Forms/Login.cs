using System;
using ContabeeComunes;
using System.Windows.Forms;
using ContabeeApi;
using ContabeeCaptura.Extensiones;
using ContabeeComunes.Sesion;

namespace ContabeeCaptura.Forms
{
    public partial class Login : Form
    {
        private readonly IApiContabee _apiContabee;
        private readonly IServicioSesion _servicioSesion;
        public Login(IApiContabee apiContabee, IServicioSesion servicioSesion)
        {
            InitializeComponent();
            _apiContabee = apiContabee;
            _servicioSesion = servicioSesion;
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
    }
}
