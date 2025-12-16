using ContabeeCaptura.Fachada;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using GdPicture;
using Serilog.Parsing;
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
using static GdPicture.GdViewer;

namespace ContabeeCaptura.Controls
{
    public partial class CtlImagen : UserControl
    {
        private IHubEventos _hub;
        private Guid _subImg;
        private Guid _subClear;
        private MemoryStream _streamActual;

        public CtlImagen()
        {
            InitializeComponent();
            this.visorImagen.SetLicenseNumber(GetGDlic());
            this.HandleDestroyed += (s, e) => LimpiarTodo();
        }

        private void LimpiarTodo()
        {
            if (_hub != null)
            {
                _hub.Desuscribir(_subImg);
                _hub.Desuscribir(_subClear);
            }

            CerrarImagen();
        }

        private void CerrarImagen()
        {
            if (visorImagen.GetStat() == GdPictureStatus.OK)
            {
                visorImagen.CloseDocument();
            }

            if (_streamActual != null)
            {
                _streamActual.Dispose();
                _streamActual = null;
            }
        }

        public void Configurar(IHubEventos hub)
        {
            _hub = hub;
            _subImg = _hub.Suscribir<ImagenBlobMensaje>(OnBytesRecibidos);
            _subClear = _hub.Suscribir<MensajeClear>(OnLimpiarUI);
        }

        private void OnLimpiarUI(MensajeClear msg)
        {
            if (this.InvokeRequired) { this.Invoke(new Action(() => OnLimpiarUI(msg))); return; }

            CerrarImagen();
        }

        private void OnBytesRecibidos(ImagenBlobMensaje msg)
        {
            if (this.InvokeRequired) { this.Invoke(new Action(() => OnBytesRecibidos(msg))); return; }

            if (msg.Imagen == null || msg.Imagen.Length == 0) return;

            try
            {
                CerrarImagen();

                _streamActual = new MemoryStream(msg.Imagen);

                visorImagen.DisplayFromStream(_streamActual);
                visorImagen.ZoomMode = ViewerZoomMode.ZoomModeFitToViewer;
                visorImagen.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error visualizando imagen: " + ex.Message);
            }
        }

        private string GetGDlic()
        {
            return ContabeeComunes.Constantes.GDPARAM.Replace("A", "4");
        }
    }
}
