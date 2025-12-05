using ContabeeApi;
using ContabeeApi.Modelos.Captura;
using ContabeeCaptura.Extensiones;
using ContabeeCaptura.Forms;
using ContabeeComunes;
using ContabeeComunes.Eventos;
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
        private readonly IApiContabee _apiContabee;
        private PaginaTrabajoCapturaCloud _pagina;
        private readonly SemaphoreSlim _refreshLock = new SemaphoreSlim(1, 1);
        public Form1(IServicioSesion servicioSesion, ITinyMessengerHub hub ,IHubEventos hubEventos, IApiContabee apiContabee)
        {
            _servicioSesion = servicioSesion as ServicioSesion;
            _hubEventos = hubEventos;
            _hub = hub;
            _apiContabee = apiContabee;
            InitializeComponent();
            SetupUI();
            this.visorImagenes.SetLicenseNumber(GetGDlic());

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

        private async void btnObtener_Click(object sender, System.EventArgs e)
        {
            try
            {
                btnObtener.Enabled = false;
                visorImagenes.CloseDocument();

                var sesionValida = await EjecutarSiNecesarioAsync();

                if (!sesionValida)
                {
                    _hubEventos.PublicarNotificacionUI(this, "Sesión Expirada, por favor inicie sesión nuevamente", TipoNotificacion.Alerta);
                }

                _hubEventos.PublicarNotificacionUI(this, "Obteniendo página...", TipoNotificacion.Info);

                var respuesta = await _apiContabee.ObtienePagina();

                if (respuesta == null)
                {
                    _hubEventos.PublicarNotificacionUI(this, "La API no devolvió ninguna respuesta.", TipoNotificacion.Error);
                    return;
                }

                if (!respuesta.Ok)
                {
                    _hubEventos.PublicarNotificacionUI(this, respuesta.Error.Mensaje ?? "Error al obtener la página.", TipoNotificacion.Error);
                    return;
                }

                if (respuesta.Payload == null)
                {
                    _hubEventos.PublicarNotificacionUI(this,"El documento está vacío.",TipoNotificacion.Alerta);
                    return;
                }

                _pagina = respuesta.Payload;

                await DescargaBlob(_pagina.TokenSas);

                _hubEventos.PublicarNotificacionUI(this, "Página cargada correctamente.", TipoNotificacion.Info);
            }
            catch (Exception ex)
            {
                _hubEventos.PublicarNotificacionUI(this, $"Ocurrió un error inesperado: {ex.Message}", TipoNotificacion.Error
                );
            }
            finally
            {
                btnObtener.Enabled = true;
            }
        }

        private async void btnCompletar_Click(object sender, EventArgs e)
        {
            var captura = Program.ServiceProvider.GetService(typeof(ContabeeCaptura.Forms.CompletarCaptura)) as ContabeeCaptura.Forms.CompletarCaptura;

            if (captura.ShowDialog() == DialogResult.OK)
            {
                await SubirArchivosBlob(captura);
                captura.finalizada.Id = _pagina.Id;
                var completar = await _apiContabee.CompletarPagina(captura.finalizada);

                if (!completar.Ok)
                {
                    _hubEventos.PublicarNotificacionUI(this, $"Error al completar la captura {completar.Error.Mensaje}", TipoNotificacion.Error);
                }
                else
                {
                    _hubEventos.PublicarNotificacionUI(this, $"Captura finalizada correctamente", TipoNotificacion.Info);
                }
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            var navegador = Program.ServiceProvider.GetService(typeof(ContabeeCaptura.Parciales.BrowserFactura)) as ContabeeCaptura.Parciales.BrowserFactura;
            if (navegador != null)
            {
                navegador.NombreBlob = Path.GetFileNameWithoutExtension(_pagina.Ruta);
                navegador.ShowDialog();
            }
        }
    }
}
