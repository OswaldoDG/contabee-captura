using ContabeeApi.Archivos;
using ContabeeCaptura.Fachada;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using System;
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

        public CtlFacturacion()
        {
            InitializeComponent();
            CopiarDatos();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.HandleDestroyed += (s, e) => {
                if (_hub != null)
                {
                    _hub.Desuscribir(_subDatos);
                    _hub.Desuscribir(_subClear);
                    _hub.Desuscribir(_subCfdi); 
                }
            };
        }

        private async void IniciarWeb()
        {
            await navegador.EnsureCoreWebView2Async(null);
            navegador.CoreWebView2.DownloadStarting += CoreWebView2_DownloadStarting;
        }

        public void Configurar(IHubEventos hub)
        {
            _hub = hub;
            _subDatos = _hub.Suscribir<NombreBlobMensaje>(OnDatosRecibidos);
            _subCfdi = _hub.Suscribir<CFDIMensaje>(OnDatosCFDI);
            _subClear = _hub.Suscribir<MensajeClear>(OnLimpiarDatos);
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
        }

        private void OnLimpiarDatos(MensajeClear msg)
        {
            _nombreBlob = string.Empty;
            textBoxFecha.Text = string.Empty;
            textBoxUUID.Text = string.Empty;

            chkBoxXML.Checked = false;
            chxBoxPDF.Checked = false;
        }

        private void CoreWebView2_DownloadStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2DownloadStartingEventArgs e)
        {
            var downloadOperation = e.DownloadOperation;

            string carpetaDestino = @"C:\comprobante";
            Directory.CreateDirectory(carpetaDestino);

            string extension = Path.GetExtension(downloadOperation.ResultFilePath).ToLower();
            string archivoTemporal = Path.Combine(carpetaDestino, "temp_descarga" + extension);

            e.ResultFilePath = archivoTemporal;
            e.Handled = false;

            downloadOperation.StateChanged += (s, ev) =>
            {
                if (downloadOperation.State ==
                    Microsoft.Web.WebView2.Core.CoreWebView2DownloadState.Completed)
                {
                    _hub.Publicar(new DescargaDetectadaMensaje
                    {
                        Sender = this,
                        NombreArchivo = _nombreBlob,
                        RutaTemp = archivoTemporal,
                        Extension = extension
                    });

                    if (extension.Equals(".xml"))
                        chkBoxXML.Checked = true;
                    if (extension.Equals(".pdf"))
                        chxBoxPDF.Checked = true;
                }
            };
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxURL.Text))
                    return;

                if (navegador.CoreWebView2 == null)
                    await navegador.EnsureCoreWebView2Async(null);

                string url = textBoxURL.Text;

                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    url = "https://" + url;

                navegador.CoreWebView2.Navigate(url);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            _hub.Publicar(new SolicitarCompletarCapturaMensaje
            {
                Sender = this,
                Total = decimal.TryParse(textBoxTotal.Text, out var valor) ? valor : 0

            });
        }

        private void CopiarDatos()
        {
            btnUUID.Tag = textBoxUUID.Text;
            btnFecha.Tag = textBoxFecha.Text;

            btnUUID.Click += Copiar_Click;
            btnFecha.Click += Copiar_Click;
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
