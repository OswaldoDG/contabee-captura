using ContabeeApi;
using ContabeeCaptura.Extensiones;
using ContabeeCaptura.Fachada;
using ContabeeComunes;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using ContabeeComunes.Sesion;
using System;
using System.IO;
using System.Threading.Tasks;
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
        private Guid _subClear;
        private Guid _subDescarga;
        private Guid _subCompletar;
        private Guid _subNombreCaptura;
        private Guid _subSiguiente;
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
            this.HandleDestroyed += (s, e) => {
                if (_hubEventos != null)
                {
                    _hubEventos.Desuscribir(_subCompletar);
                    _hubEventos.Desuscribir(_subDescarga);
                    _hubEventos.Desuscribir(_subNombreCaptura);
                    _hubEventos.Desuscribir(_subClear);
                    _hubEventos.Desuscribir(_subSiguiente);
                }
            };
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.UserPaint, true);
            UpdateStyles();
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
            _subClear = _hubEventos.Suscribir<MensajeClear>(OnLimpiarDatos);
            _subCompletar = _hubEventos.Suscribir<CompletarCapturaMensaje>(OnCompletarDatos);
            _subDescarga = _hubEventos.Suscribir<DescargaDetectadaMensaje>(OnDescargaDetectada);
            _subNombreCaptura = _hubEventos.Suscribir<NombreBlobMensaje>(OnNombreMensajeDetectado);
            _subSiguiente = _hubEventos.Suscribir<SiguienteMensaje>(OnSiguienteActivacion);
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

        private void OnLimpiarDatos(MensajeClear msg)
        {
            if (msg == null) return;

            if (this.InvokeRequired) { this.Invoke(new Action(() => OnLimpiarDatos(msg))); return; }

            labelBlob.Text = "PROCESO DE CAPTURA";
        }

        private void OnSiguienteActivacion(SiguienteMensaje msg)
        {
            if (msg == null) return;

            if (this.InvokeRequired) { this.Invoke(new Action(() => OnSiguienteActivacion(msg))); return; }

            btnSiguiente.Enabled = true;
        }

        private void OnNombreMensajeDetectado(NombreBlobMensaje msg)
        {
            if (msg == null) return;

            if (this.InvokeRequired) { this.Invoke(new Action(() => OnNombreMensajeDetectado(msg))); return; }

            labelBlob.Text = "PROCESO DE CAPTURA LOTE " + Path.GetDirectoryName(msg.NombreBlob) + " COMPROBANTE " + Path.GetFileNameWithoutExtension(msg.NombreBlob);
        }

        private async void OnCompletarDatos(CompletarCapturaMensaje msg)
        {
            if (msg == null) return;


            if (this.InvokeRequired) { this.Invoke(new Action(() => OnCompletarDatos(msg))); return; }

            if (msg.Archivos.Count > 0) 
            { 
                var respuestaArchivos = await _servicioFachada.SubirArchivosAsync(msg.Archivos); 
            }

            var respuesta = await _servicioFachada.CompletarCapturaAsync(msg.CapturaCompleta);


            _hubEventos.Publicar(new MensajeClear()
            {
                Sender = this
            });
        }

        private async void OnDescargaDetectada(DescargaDetectadaMensaje msg)
        {
            if (msg == null) return;


            if (this.InvokeRequired) { this.Invoke(new Action(() => OnDescargaDetectada(msg))); return; }

            var r = await _servicioFachada.DescargaProcesamientoXML(msg.NombreArchivo, msg.RutaTemp, msg.Extension);
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
