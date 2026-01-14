using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabeeCaptura.Parciales
{
    public partial class BrowserFactura : Form
    {
        public string NombreBlob { get; set; }

        public BrowserFactura()
        {
            InitializeComponent();
            IniciarWeb();
        }

        private async void IniciarWeb()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.DownloadStarting += CoreWebView2_DownloadStarting;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBxUrl.Text))
            {
                if (webView21.CoreWebView2 == null)
                {
                    await webView21.EnsureCoreWebView2Async(null);
                }

                string url = txtBxUrl.Text;

                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                webView21.CoreWebView2.Navigate(url);
            }
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
                if (downloadOperation.State == Microsoft.Web.WebView2.Core.CoreWebView2DownloadState.Completed)
                {
                    ProcesarDescarga(archivoTemporal, extension);
                }
            };
        }

        private void ProcesarDescarga(string rutaTemp, string extension)
        {
            string carpetaDestinoBase = @"C:\comprobante";
            string carpetaBlob = Path.Combine(carpetaDestinoBase, NombreBlob);
            Directory.CreateDirectory(carpetaBlob);

            try
            {
                if (extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    string rutaFinal = Path.Combine(carpetaBlob, NombreBlob + extension);
                    File.Copy(rutaTemp, rutaFinal, true);
                    File.Delete(rutaTemp);
                }
                else if (extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(rutaTemp, carpetaBlob);

                    File.Delete(rutaTemp);

                    var archivos = Directory.GetFiles(carpetaBlob, "*.*", SearchOption.AllDirectories);
                    int contador = 1;

                    foreach (var archivo in archivos)
                    {
                        string ext = Path.GetExtension(archivo);
                        string rutaDirectorio = Path.GetDirectoryName(archivo);

                        string nuevoNombre = NombreBlob;

                        if (archivos.Length > 1)
                            nuevoNombre += $"_{contador++}";

                        nuevoNombre += ext;

                        string rutaDestino = Path.Combine(rutaDirectorio, nuevoNombre);
                        if (!archivo.Equals(rutaDestino, StringComparison.OrdinalIgnoreCase))
                        {
                            if (File.Exists(rutaDestino))
                                File.Delete(rutaDestino);

                            File.Move(archivo, rutaDestino);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar descarga: " + ex.Message);
            }
        }


    }
}
