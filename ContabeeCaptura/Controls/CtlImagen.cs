using ContabeeCaptura.Fachada;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using GdPicture;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ContabeeCaptura.Controls
{
    public partial class CtlImagen : UserControl
    {
        private IHubEventos _hub;
        private Guid _subImg;
        private Guid _subClear;
        private Stream _streamActual;
        private int _imageId;

        public CtlImagen()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
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
            if (_imageId != 0)
            {
                var gd = new GdPictureImaging();
                gd.ReleaseGdPictureImage(_imageId);
                _imageId = 0;
            }

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
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => OnLimpiarUI(msg))); return; }

            CerrarImagen();
        }

        private void OnBytesRecibidos(ImagenBlobMensaje msg)
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => OnBytesRecibidos(msg))); return; }

            if (msg.Imagen == null || msg.Imagen.Length == 0) return;

            try
            {
                CerrarImagen();
                var gd = new GdPictureImaging();
                _streamActual = new MemoryStream(msg.Imagen);

                _imageId = gd.CreateGdPictureImageFromStream(_streamActual);

                visorImagen.DisplayFromGdPictureImage(_imageId);
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

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (_imageId == 0) return;

            var gd = new GdPictureImaging();
            gd.Rotate(_imageId, RotateFlipType.Rotate270FlipNone);

            visorImagen.DisplayFromGdPictureImage(_imageId);
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            if (_imageId == 0) return;

            var gd = new GdPictureImaging();
            gd.Rotate(_imageId, RotateFlipType.Rotate90FlipNone);

            visorImagen.DisplayFromGdPictureImage(_imageId);
        }
    }
}
