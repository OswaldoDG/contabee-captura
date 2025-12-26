using ContabeeApi;
using ContabeeCaptura.Extensiones;
using ContabeeCaptura.Fachada;
using ContabeeComunes;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using ContabeeComunes.Sesion;
using System;
using System.Windows.Forms;
using TinyMessenger;

namespace ContabeeCaptura
{
    public partial class Form1 : Form
    {
        private readonly ServicioSesion _servicioSesion;
        private readonly IHubEventos _hubEventos;
        private readonly ITinyMessengerHub _hub;
        private readonly IServicioFachada _servicioFachada;
        private Guid _subDialog;
        private Guid _subCFDI;
        private string _UUID;
        private DateTime? _FechaCFDI = null;
        public Form1(IServicioFachada servicioFachada, IServicioSesion servicioSesion, ITinyMessengerHub hub ,IHubEventos hubEventos, IApiContabee apiContabee)
        {
            _servicioSesion = servicioSesion as ServicioSesion;
            _hub = hub;
            _hubEventos = hubEventos;
            _servicioFachada = servicioFachada;

            InitializeComponent();
            ConfiguracionBtnSplit();
            ctlDatosFiscales2.Configurar(_hubEventos, _servicioSesion);
            ctlImagen2.Configurar(_hubEventos);
            ctlOCR2.Configurar(_hubEventos);
            ctlFacturacion2.Configurar(_hubEventos);
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
            _subDialog = _hubEventos.Suscribir<MostrarCompletarCapturaDialogMensaje>(OnMostrarDialog);
            _subCFDI = _hubEventos.Suscribir<CFDIMensaje>(OnDatosCFDI);
        }

        private async void OnMostrarDialog(MostrarCompletarCapturaDialogMensaje msg)
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => OnMostrarDialog(msg))); return; }

            var captura = Program.ServiceProvider.GetService(typeof(ContabeeCaptura.Forms.CompletarCaptura)) as ContabeeCaptura.Forms.CompletarCaptura;

            if (captura.ShowDialog(this) == DialogResult.OK)
            {

                if (_UUID != null && _FechaCFDI != null)
                {
                    captura.finalizada.FechaCfdi = (DateTime)_FechaCFDI;
                    captura.finalizada.CfdiId = _UUID;
                }
                captura.finalizada.Total = msg.Total;
                await _servicioFachada.CompletarCapturaAsync(captura.finalizada, captura.comprobantesPath);
            }
        }

        private async void OnDatosCFDI(CFDIMensaje msg)
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => OnDatosCFDI(msg))); return; }

            this._UUID = msg.UUID;
            this._FechaCFDI = msg.Fecha;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _hubEventos.PublicarNotificacionUI(this, "Este es un mensaje de prueba", TipoNotificacion.Error);  
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void btnSiguiente_Click(object sender, EventArgs e)
        {
            btnSiguiente.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                await _servicioFachada.SiguienteTrabajoAsync();
            }
            catch (Exception ex)
            {
                _hubEventos.PublicarNotificacionUI(this, $"Ocurrió un error inesperado: {ex.Message}", TipoNotificacion.Error);
            }
            finally
            {
                btnSiguiente.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfiguracionBtnSplit()
        {
            btnPosSplit1.Tag = 1.0 / 3.0;
            btnPosSplit2.Tag = 1.0 / 2.0;
            btnPosSplit3.Tag = 2.0 / 3.0;

            btnPosSplit1.Click += PosicionSplit_Click;
            btnPosSplit2.Click += PosicionSplit_Click;
            btnPosSplit3.Click += PosicionSplit_Click;

        }

        private void PosicionSplit_Click(object sender, EventArgs e)
        {
            if (sender is Button boton && boton.Tag is double porcentaje)
            {
                CambiarSplitContainer(porcentaje);
            }
        }

        private void CambiarSplitContainer(double porcentaje)
        {
            int tamañoTotal;

            if (splitContainer2.Orientation == Orientation.Vertical)
                tamañoTotal = splitContainer2.Width;
            else
                tamañoTotal = splitContainer2.Height;

            int nuevaDistancia = (int)(tamañoTotal * porcentaje);

            int minimo = splitContainer2.Panel1MinSize;
            int maximo = tamañoTotal - splitContainer2.Panel2MinSize;

            if (nuevaDistancia < minimo)
                nuevaDistancia = minimo;

            if (nuevaDistancia > maximo)
                nuevaDistancia = maximo;

            splitContainer2.SplitterDistance = nuevaDistancia;
        }
    }
}
