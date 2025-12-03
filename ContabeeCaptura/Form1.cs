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
                var http = new HttpClient();
                var response = await http.GetAsync(_pagina.TokenSas);

                if (!response.IsSuccessStatusCode)
                {
                    _hubEventos.PublicarNotificacionUI(this, "Ocurrió un problema al bajar el archivo de la nube", TipoNotificacion.Error);
                }

                var status = visorImagenes.DisplayFromStream(await response.Content.ReadAsStreamAsync());
                ProcesaInicioTrabajo(_pagina);
                //_apiContabee.ComputerVision(await response.Content.ReadAsStreamAsync());
                visorImagenes.Visible = true;
                visorImagenes.Focus();

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
                var datos = captura.finalizada;
                var comprobantes = captura.comprobantesPath;
                datos.Id = _pagina.Id;

                if (comprobantes != null && comprobantes.Count > 0)
                {
                    using (var http = new HttpClient())
                    {
                        foreach (var archivoLocal in comprobantes)
                        {
                            var nombreArchivo = Path.GetFileName(archivoLocal);
                            var uri = new Uri(_pagina.TokenSas);
                            var segmentos = uri.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                            string urlBlob = $"{uri.Scheme}://{uri.Host}/{segmentos[0]}/{_pagina.LoteId}/{nombreArchivo}?{uri.Query.TrimStart('?')}";


                            using (var fs = new FileStream(archivoLocal, FileMode.Open, FileAccess.Read))
                            {
                                var content = new StreamContent(fs);
                                content.Headers.Add("x-ms-blob-type", "BlockBlob");

                                var response = await http.PutAsync(urlBlob, content);
                                if (!response.IsSuccessStatusCode)
                                {
                                    _hubEventos.PublicarNotificacionUI(this, $"Error al subir {archivoLocal}.", TipoNotificacion.Error);
                                }
                            }
                        }
                    }

                    _hubEventos.PublicarNotificacionUI(this, $"Archivos subidos correctamente.", TipoNotificacion.Info);
                }

                var completar = await _apiContabee.CompletarPagina(datos);

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

        /// <summary>
        /// Muestra la informacion de la Pagina.
        /// </summary>
        /// <param name="pagina"></param>
        private void ProcesaInicioTrabajo(PaginaTrabajoCapturaCloud pagina)
        {
            labelBoxRfc.Informacion = pagina.Rfc;
            labelBoxPago.Informacion = pagina.FormaPago;
            labelBoxUso.Informacion = pagina.UsoFactura;
            labelBoxCP.Informacion = pagina.CodigoPostal;
            labelBoxTarjeta.Informacion = pagina.TerminacionPago;
            labelBoxNombre.Informacion = pagina.Denominacion;
            labelBoxDireccion.Informacion = pagina.Direccion;
        }

        /// <summary>
        /// Realiza el refresco de token de ser necesario.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> EjecutarSiNecesarioAsync()
        {
            if (_servicioSesion.IsAuthenticated && !_servicioSesion.NeedsRefresh())
                return true;

            if (string.IsNullOrEmpty(_servicioSesion.ObtenerInfoAccesso().refresh_token))
            {
                _servicioSesion.Clear();
                return false;
            }

            await _refreshLock.WaitAsync();

            try
            {
                if (!_servicioSesion.NeedsRefresh())
                    return true;

                var respuesta = await _apiContabee.RefreshToken(_servicioSesion.ObtenerInfoAccesso().refresh_token);

                if (!respuesta.Ok)
                {
                    _servicioSesion.Clear();
                    return false;
                }
                _servicioSesion.EstablecerSesion(_servicioSesion.ObtenerNombreUsuario(), respuesta.Payload);
                return true;
            }
            finally
            {
                _refreshLock.Release();
            }
        }
    }
}
