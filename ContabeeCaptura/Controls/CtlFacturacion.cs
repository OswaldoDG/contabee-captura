using ContabeeApi.Archivos;
using ContabeeApi.Modelos;
using ContabeeApi.Modelos.Captura;
using ContabeeCaptura.Fachada;
using ContabeeComunes;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ContabeeCaptura.Controls
{
    public partial class CtlFacturacion : UserControl
    { 
        private IHubEventos _hub;
        private string _nombreBlob = "";
        private Guid _subDatos;
        private Guid _subClear;
        private Guid _subCfdi;
        private Guid _subIEPS;
        public List<string> comprobantesPath = new List<string>();

        public CtlFacturacion()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.UserPaint, true);
            UpdateStyles();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.HandleDestroyed += (s, e) => {
                if (_hub != null)
                {
                    _hub.Desuscribir(_subDatos);
                    _hub.Desuscribir(_subClear);
                    _hub.Desuscribir(_subCfdi); 
                    _hub.Desuscribir(_subIEPS);
                }
            };
        }

        private async void IniciarWeb()
        {
            await navegador.EnsureCoreWebView2Async(null);
            navegador.CoreWebView2.Navigate("https://www.google.com");
            navegador.NavigationCompleted += Navegador_NavigationCompleted;
            navegador.CoreWebView2.DownloadStarting += CoreWebView2_DownloadStarting;
            navegador.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
        }

        private void CoreWebView2_NewWindowRequested(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;
            navegador.CoreWebView2.Navigate(e.Uri);
        }

        private void Navegador_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            textBoxURL.Text = navegador.Source.ToString();
            txtBxUrl.Text = textBoxURL.Text;
            btnAtras.Enabled = navegador.CanGoBack;
            btnAdelante.Enabled = navegador.CanGoForward;
        }

        public void Configurar(IHubEventos hub)
        {
            _hub = hub;
            _subDatos = _hub.Suscribir<NombreBlobMensaje>(OnDatosRecibidos);
            _subCfdi = _hub.Suscribir<CFDIMensaje>(OnDatosCFDI);
            _subClear = _hub.Suscribir<MensajeClear>(OnLimpiarDatos);
            _subIEPS = _hub.Suscribir<DesglosarIEPSMensaje>(OnDesglosarIEPS);
            IniciarWeb();
        }

        private void OnDatosRecibidos(NombreBlobMensaje msg)
        {
            if (msg == null) return;

            _nombreBlob = msg.NombreBlob;
        }

        private void OnDatosCFDI(CFDIMensaje msg)
        {
            if (msg == null) return;


            if (this.InvokeRequired) { this.Invoke(new Action(() => OnDatosCFDI(msg))); return; }


            textBoxUUID.Text = msg.UUID;
            textBoxFecha.Text = msg.Fecha.ToString();
            textBoxTotal.Text = msg.Total.ToString();
        }

        private void OnLimpiarDatos(MensajeClear msg)
        {
            if (msg == null) return;


            if (this.InvokeRequired) { this.Invoke(new Action(() => OnLimpiarDatos(msg))); return; }

            _nombreBlob = string.Empty;
            comprobantesPath.Clear();
            listViewComprobantes.Clear();
            labelIEPS.Visible = false;
            textBoxURL.Text = string.Empty;
            cbxTipoFuente.SelectedItem = null;
            cbxMotivo.SelectedItem = null;
            sinChxXml.Checked = true;
            sinChxPdf.Checked = true;
            txtBxUrl.Text = string.Empty;
            cbxTieneCaptcha.Checked = false;
            textBoxFecha.Text = string.Empty;
            textBoxUUID.Text = string.Empty;
            txtBxComentario.Text = string.Empty;
            textBoxTotal.Text = string.Empty;
            cbxReprogramar.SelectedItem = null;
            btnFinalizar.Enabled = false;
            navegador.Source = new Uri("https://www.google.com");
        }
        
        private void OnDesglosarIEPS(DesglosarIEPSMensaje msg)
        {
            if (msg == null) return;

            if (this.InvokeRequired) { this.Invoke(new Action(() => OnDesglosarIEPS(msg))); return; }

            labelIEPS.Visible = msg.DesglosarIEPS;
        }

        private void CoreWebView2_DownloadStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2DownloadStartingEventArgs e)
        {
            var downloadOperation = e.DownloadOperation;

            string carpetaDestino = @"C:\comprobante";
            Directory.CreateDirectory(carpetaDestino);

            string nombreArchivo = Path.GetFileName(e.ResultFilePath);
            string extension = Path.GetExtension(nombreArchivo).ToLower();

            string rutaFinal = Path.Combine(carpetaDestino, nombreArchivo);

            e.ResultFilePath = rutaFinal;
            e.Handled = true;

            downloadOperation.StateChanged += DownloadOperation_StateChanged;
        }

        private void DownloadOperation_StateChanged(object sender, object e)
        {
            var download = (CoreWebView2DownloadOperation)sender;

            if (download.State == CoreWebView2DownloadState.Completed)
            {
                if ((ulong)download.BytesReceived == download.TotalBytesToReceive)
                {
                    var extension = Path.GetExtension(download.ResultFilePath);
                    _hub.PublicarNotificacionUI(this, "La descarga se completó satisfactoriamente", TipoNotificacion.Info);

                    _hub.Publicar(new DescargaDetectadaMensaje
                    {
                        Sender = this,
                        NombreArchivo = _nombreBlob,
                        RutaTemp = download.ResultFilePath,
                        Extension = extension
                    });

                    if (extension.Equals(".xml"))
                    {
                        sinChxXml.Checked = false;
                    }

                    if (extension.Equals(".pdf"))
                    {
                        sinChxPdf.Checked = false;
                    }
                }

            }
            else if (download.State == CoreWebView2DownloadState.Interrupted)
            {
                _hub.PublicarNotificacionUI(this, "La descarga se completó satisfactoriamente", TipoNotificacion.Info);
            }

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxURL.Text))
                    return;

                if (navegador.CoreWebView2 == null)
                    await navegador.EnsureCoreWebView2Async();

                string texto = textBoxURL.Text.Trim();
                string url;

                if (texto.Contains(".") && !texto.Contains(" "))
                {
                    if (!texto.StartsWith("http://") && !texto.StartsWith("https://"))
                        texto = "https://" + texto;

                    url = texto;
                }
                else
                {
                    url = "https://www.google.com/search?q=" + Uri.EscapeDataString(texto);
                }

                navegador.CoreWebView2.Navigate(url);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void btnComprobantes_Click(object sender, EventArgs e)
        {
            if (comprobantesPath.Count >= 2)
            {
                _hub.PublicarNotificacionUI(this, "Seleccione únicamente 2 comprobantes (PDF o XML)", TipoNotificacion.Alerta);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Archivos permitidos|*.pdf;*.jpg;*.jpeg;*.png;*.xml;*.html;*.txt;*.json;*.csv";
                ofd.InitialDirectory = @"C:\comprobante";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    listViewComprobantes.BeginUpdate();
                    try
                    {
                        foreach (string file in ofd.FileNames)
                        {
                            if (comprobantesPath.Count >= 2)
                            {
                                _hub.PublicarNotificacionUI(this, "Solo se permiten 2 comprobantes (PDF o XML).", TipoNotificacion.Alerta);
                                break;
                            }

                            if (Path.GetExtension(file).Equals(".xml"))
                            {
                                sinChxXml.Checked = false;
                            }

                            if (Path.GetExtension(file).Equals(".pdf"))
                            {
                                sinChxPdf.Checked = false;
                            }

                            comprobantesPath.Add(file);

                            FileInfo fi = new FileInfo(file);

                            ListViewItem item = new ListViewItem(fi.Name);

                            listViewComprobantes.Items.Add(item);
                        }
                    }
                    finally
                    {
                        listViewComprobantes.EndUpdate();
                    }
                    
                }
            }
        }

        private void BtnRemoverComprobante_Click(object sender, EventArgs e)
        {
            if (listViewComprobantes.SelectedItems.Count == 0)
            {
                _hub.PublicarNotificacionUI(this, "Selecciona un archivo para eliminar", TipoNotificacion.Alerta);
                return;
            }

            var item = listViewComprobantes.SelectedItems[0];
            int index = item.Index;

            comprobantesPath.RemoveAt(index);
            listViewComprobantes.Items.RemoveAt(index);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (navegador.CanGoBack)
                navegador.GoBack();
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            if (navegador.CanGoForward)
                navegador.GoForward();
        }

        private void btnRecarga_Click(object sender, EventArgs e)
        {
            navegador.Reload();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelarDatos();

        }

        private void CancelarDatos()
        {
            _nombreBlob = string.Empty;
            comprobantesPath.Clear();
            listViewComprobantes.Clear();
            labelIEPS.Visible = false;
            textBoxURL.Text = string.Empty;
            cbxTipoFuente.SelectedItem = null;
            cbxMotivo.SelectedItem = null;
            sinChxXml.Checked = true;
            sinChxPdf.Checked = true; 
            txtBxUrl.Text = string.Empty;
            cbxTieneCaptcha.Checked = false;
            textBoxFecha.Text = string.Empty;
            textBoxUUID.Text = string.Empty;
            txtBxComentario.Text = string.Empty;
            textBoxTotal.Text = string.Empty;
            cbxReprogramar.SelectedItem = null;
            btnFinalizar.Enabled = false;

            navegador.Source = new Uri("https://www.google.com");

            _hub.Publicar(new MensajeClear() { Sender = this});
            _hub.Publicar(new SiguienteMensaje()
            {
                Sender = this,
                ActivarSiguiente = true
            });
        }

        private void cbxReprogramar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFinalizar.Enabled = cbxReprogramar.SelectedIndex != -1;
        }

        private void btnFinalizar_Click_1(object sender, EventArgs e)
        {
            btnFinalizar.Enabled = false;

            _hub.PublicarNotificacionUI(this, "Por favor espere, se está finalizando la captura. Cuando se limpien los datos de la pantalla puede continuar.", TipoNotificacion.Alerta);

            var completar = new CompletarCapturaPagina()
            {
                Reprogramar = cbxReprogramar.Text.Equals("Finalizar", StringComparison.OrdinalIgnoreCase) ? false : true,
                Motivo = Enum.TryParse(cbxMotivo.Text, out MotivoEstado motivo) ? motivo : MotivoEstado.OtroError,
                TipoFuente = Enum.TryParse(cbxTipoFuente.Text, out TipoFuenteProcesamiento tipoFuente) ? tipoFuente : TipoFuenteProcesamiento.Ninguno,
                Comentario = string.IsNullOrWhiteSpace(txtBxComentario.Text) ? "" : txtBxComentario.Text,
                SinXml = sinChxXml.Checked,
                SinPdf = sinChxPdf.Checked,
                Url = string.IsNullOrWhiteSpace(txtBxUrl.Text) ? "" : textBoxURL.Text,
                TieneCaptcha = cbxTieneCaptcha.Checked,
                Total = decimal.TryParse(textBoxTotal.Text, out var valor) ? valor : 0,
                CfdiId = string.IsNullOrWhiteSpace(textBoxUUID.Text) ? "" : textBoxUUID.Text
            };

            if (DateTime.TryParse(textBoxFecha.Text, out DateTime temp))
            {
                completar.FechaCfdi = temp;
            }
            else
            {
                completar.FechaCfdi = null;
            }

            _hub.Publicar(new CompletarCapturaMensaje
            {
                Sender = this,
                CapturaCompleta = completar,
                Archivos = comprobantesPath
            });
        }
    }
}
