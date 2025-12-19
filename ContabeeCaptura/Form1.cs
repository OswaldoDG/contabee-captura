using ContabeeApi;
using ContabeeApi.Modelos.Captura;
using ContabeeCaptura.Extensiones;
using ContabeeCaptura.Fachada;
using ContabeeCaptura.Forms;
using ContabeeComunes;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using ContabeeComunes.RespuestaApi;
using ContabeeComunes.Sesion;
using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
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
            ctlDatosFiscales1.Configurar(_hubEventos);
            ctlImagen1.Configurar(_hubEventos);
            ctlOCR1.Configurar(_hubEventos);
            ctlFacturacion1.Configurar(_hubEventos);
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

        //private async void btnCompletar_Click(object sender, EventArgs e)
        //{
        //    var captura = Program.ServiceProvider.GetService(typeof(App.Forms.CompletarCaptura)) as App.Forms.CompletarCaptura;

        //    if (captura.ShowDialog() == DialogResult.OK)
        //    {
        //        await SubirArchivosBlob(captura);
        //        captura.finalizada.Id = _pagina.Id;
        //        var completar = await _apiBackend.CompletarPagina(captura.finalizada);

        //        if (!completar.Ok)
        //        {
        //            _hubEventos.PublicarNotificacionUI(this, $"Error al completar la captura {completar.Error.Mensaje}", TipoNotificacion.Error);
        //        }
        //        else
        //        {
        //            _hubEventos.PublicarNotificacionUI(this, $"Captura finalizada correctamente", TipoNotificacion.Info);
        //        }
        //    }
        //}

        //private void btnFacturar_Click(object sender, EventArgs e)
        //{
        //    var navegador = Program.ServiceProvider.GetService(typeof(ContabeeCaptura.Parciales.BrowserFactura)) as ContabeeCaptura.Parciales.BrowserFactura;
        //    if (navegador != null)
        //    {
        //        navegador.NombreBlob = Path.GetFileNameWithoutExtension(_pagina.Ruta);
        //        navegador.ShowDialog();
        //    }
        //}

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
    }
}
