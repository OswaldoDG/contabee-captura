namespace ContabeeCaptura.Controls
{
    partial class CtlImagen
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.visorImagen = new GdPicture.GdViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.visorImagen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 580);
            this.panel1.TabIndex = 0;
            // 
            // visorImagen
            // 
            this.visorImagen.AnimateGIF = true;
            this.visorImagen.BackColor = System.Drawing.Color.Black;
            this.visorImagen.BackgroundImage = null;
            this.visorImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.visorImagen.ContinuousViewMode = true;
            this.visorImagen.Cursor = System.Windows.Forms.Cursors.Default;
            this.visorImagen.DisplayQuality = GdPicture.DisplayQuality.DisplayQualityBicubicHQ;
            this.visorImagen.DisplayQualityAuto = false;
            this.visorImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visorImagen.DocumentAlignment = GdPicture.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
            this.visorImagen.DocumentPosition = GdPicture.ViewerDocumentPosition.DocumentPositionMiddleCenter;
            this.visorImagen.EnabledProgressBar = true;
            this.visorImagen.EnableMenu = true;
            this.visorImagen.EnableMouseWheel = true;
            this.visorImagen.ForceScrollBars = false;
            this.visorImagen.ForceTemporaryModeForImage = false;
            this.visorImagen.ForceTemporaryModeForPDF = false;
            this.visorImagen.ForeColor = System.Drawing.Color.Black;
            this.visorImagen.Gamma = 1F;
            this.visorImagen.HQAnnotationRendering = true;
            this.visorImagen.IgnoreDocumentResolution = false;
            this.visorImagen.KeepDocumentPosition = false;
            this.visorImagen.Location = new System.Drawing.Point(0, 0);
            this.visorImagen.LockViewer = false;
            this.visorImagen.MagnifierHeight = 90;
            this.visorImagen.MagnifierWidth = 160;
            this.visorImagen.MagnifierZoomX = 2F;
            this.visorImagen.MagnifierZoomY = 2F;
            this.visorImagen.MouseButtonForMouseMode = GdPicture.MouseButton.MouseButtonLeft;
            this.visorImagen.MouseMode = GdPicture.ViewerMouseMode.MouseModePan;
            this.visorImagen.MouseWheelMode = GdPicture.ViewerMouseWheelMode.MouseWheelModeZoom;
            this.visorImagen.Name = "visorImagen";
            this.visorImagen.OptimizeDrawingSpeed = false;
            this.visorImagen.PdfDisplayFormField = true;
            this.visorImagen.PdfEnableLinks = true;
            this.visorImagen.PDFShowDialogForPassword = true;
            this.visorImagen.RectBorderColor = System.Drawing.Color.Black;
            this.visorImagen.RectBorderSize = 1;
            this.visorImagen.RectIsEditable = true;
            this.visorImagen.RegionsAreEditable = true;
            this.visorImagen.ScrollBars = true;
            this.visorImagen.ScrollLargeChange = ((short)(50));
            this.visorImagen.ScrollSmallChange = ((short)(1));
            this.visorImagen.SilentMode = true;
            this.visorImagen.Size = new System.Drawing.Size(781, 580);
            this.visorImagen.TabIndex = 0;
            this.visorImagen.Zoom = 1D;
            this.visorImagen.ZoomCenterAtMousePosition = false;
            this.visorImagen.ZoomMode = GdPicture.ViewerZoomMode.ZoomMode100;
            this.visorImagen.ZoomStep = 25;
            // 
            // CtlImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CtlImagen";
            this.Size = new System.Drawing.Size(781, 580);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GdPicture.GdViewer visorImagen;
    }
}
