using ContabeeCaptura.Fachada;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using ContabeeComunes.Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabeeCaptura.Controls
{
    public partial class CtlDatosFiscales : UserControl
    {
        private IHubEventos _hub;
        private Guid _subDatos;
        private Guid _subClear;
        private ServicioSesion _servicioSesion;
        public CtlDatosFiscales()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.UserPaint, true);
            UpdateStyles();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            CopiarDatos();

            this.HandleDestroyed += (s, e) => {
                if (_hub != null)
                {
                    _hub.Desuscribir(_subDatos);
                    _hub.Desuscribir(_subClear);
                }
            };
        }

        public void Configurar(IHubEventos hub, ServicioSesion servicioSesion)
        {
            _hub = hub;
            _servicioSesion = servicioSesion;
            _subDatos = _hub.Suscribir<DatosFiscalesMensaje>(OnDatosRecibidos);
            _subClear = _hub.Suscribir<MensajeClear>(OnLimpiarUI);
        }

        private void OnLimpiarUI(MensajeClear msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => OnLimpiarUI(msg)));
                return;
            }

            textBoxRFC.Text = "";
            textBoxPago.Text = "";
            textBoxUso.Text = "";
            textBoxCP.Text = "";
            textBoxTarjeta.Text = "";
            textBoxRegimen.Text = "";
            textBoxCorreo.Text = "";
            textBoxDomicilio.Text = "";
            textBoxNombre.Text = "";
            textBoxComentario.Text = "";
        }

        private void OnDatosRecibidos(DatosFiscalesMensaje msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => OnDatosRecibidos(msg)));
                return;
            }

            if (msg.Datos != null)
            {
                textBoxRFC.Text = msg.Datos.Rfc;
                textBoxPago.Text = msg.Datos.FormaPago;
                textBoxUso.Text = msg.Datos.UsoFactura;
                textBoxCP.Text = msg.Datos.CodigoPostal;
                textBoxTarjeta.Text = msg.Datos.TerminacionPago;
                textBoxRegimen.Text = msg.Datos.RegimenFiscal;
                textBoxCorreo.Text = _servicioSesion.ObtenerNombreUsuario();
                textBoxDomicilio.Text = msg.Datos.Direccion;
                textBoxNombre.Text = msg.Datos.Denominacion;
                textBoxComentario.Text = msg.Datos.Comentarios;
            }
        }

        private void CopiarDatos()
        {
            btnRFC.Tag = textBoxRFC;
            btnPago.Tag = textBoxPago;
            btnUso.Tag = textBoxUso;
            btnTarjeta.Tag = textBoxTarjeta;
            btnCP.Tag = textBoxCP;
            btnRegimen.Tag = textBoxRegimen;
            btnCorreo.Tag = textBoxCorreo;
            btnDomicilio.Tag = textBoxDomicilio;
            btnCorreo.Tag = textBoxCorreo;
            btnNombre.Tag = textBoxNombre;
            btnComentario.Tag = textBoxComentario;

            btnRFC.Click += Copiar_Click;
            btnPago.Click += Copiar_Click;
            btnUso.Click += Copiar_Click;
            btnTarjeta.Click += Copiar_Click;
            btnCP.Click += Copiar_Click;
            btnRegimen.Click += Copiar_Click;
            btnCorreo.Click += Copiar_Click;
            btnDomicilio.Click += Copiar_Click;
            btnCorreo.Click += Copiar_Click;
            btnNombre.Click += Copiar_Click;
            btnComentario.Click += Copiar_Click;
        }

        private void Copiar_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is TextBox txt)
            {
                Clipboard.SetText(txt.Text);
            }
        }
    }
}
