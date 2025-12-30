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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.visorImagen = new GdPicture.GdViewer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDerecha = new System.Windows.Forms.Button();
            this.btnIzquierda = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.visorImagen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 580);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // visorImagen
            // 
            this.visorImagen.AnimateGIF = false;
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
            this.visorImagen.Location = new System.Drawing.Point(3, 3);
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
            this.visorImagen.Size = new System.Drawing.Size(775, 516);
            this.visorImagen.TabIndex = 1;
            this.visorImagen.Zoom = 1D;
            this.visorImagen.ZoomCenterAtMousePosition = false;
            this.visorImagen.ZoomMode = GdPicture.ViewerZoomMode.ZoomMode100;
            this.visorImagen.ZoomStep = 25;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnDerecha, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnIzquierda, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 525);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(775, 52);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnDerecha
            // 
            this.btnDerecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDerecha.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDerecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDerecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDerecha.Location = new System.Drawing.Point(545, 2);
            this.btnDerecha.Margin = new System.Windows.Forms.Padding(2);
            this.btnDerecha.Name = "btnDerecha";
            this.btnDerecha.Size = new System.Drawing.Size(71, 48);
            this.btnDerecha.TabIndex = 40;
            this.btnDerecha.Text = "↻";
            this.btnDerecha.UseVisualStyleBackColor = false;
            this.btnDerecha.Click += new System.EventHandler(this.btnDerecha_Click);
            // 
            // btnIzquierda
            // 
            this.btnIzquierda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIzquierda.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnIzquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIzquierda.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzquierda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIzquierda.Location = new System.Drawing.Point(158, 2);
            this.btnIzquierda.Margin = new System.Windows.Forms.Padding(2);
            this.btnIzquierda.Name = "btnIzquierda";
            this.btnIzquierda.Size = new System.Drawing.Size(71, 48);
            this.btnIzquierda.TabIndex = 39;
            this.btnIzquierda.Text = "↺ Rotar Izquierda";
            this.btnIzquierda.UseVisualStyleBackColor = false;
            this.btnIzquierda.Click += new System.EventHandler(this.btnIzquierda_Click);
            // 
            // CtlImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtlImagen";
            this.Size = new System.Drawing.Size(781, 580);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GdPicture.GdViewer visorImagen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnIzquierda;
        private System.Windows.Forms.Button btnDerecha;
    }
}
