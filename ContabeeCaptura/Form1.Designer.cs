namespace ContabeeCaptura
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statuLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnCompletar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnObtener = new System.Windows.Forms.Button();
            this.visorImagenes = new GdPicture.GdViewer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.txtBoxOCR = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelBoxDireccion = new ContabeeCaptura.Controls.LabelBox();
            this.labelBoxNombre = new ContabeeCaptura.Controls.LabelBox();
            this.labelBoxTarjeta = new ContabeeCaptura.Controls.LabelBox();
            this.labelBoxCP = new ContabeeCaptura.Controls.LabelBox();
            this.labelBoxUso = new ContabeeCaptura.Controls.LabelBox();
            this.labelBoxPago = new ContabeeCaptura.Controls.LabelBox();
            this.labelBoxRfc = new ContabeeCaptura.Controls.LabelBox();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(900, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuLabel
            // 
            this.statuLabel.Image = global::ContabeeCaptura.Properties.Resources.alert_info_icon;
            this.statuLabel.Name = "statuLabel";
            this.statuLabel.Size = new System.Drawing.Size(20, 20);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 306);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 536);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1MinSize = 35;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelBoxDireccion);
            this.splitContainer1.Panel2.Controls.Add(this.labelBoxNombre);
            this.splitContainer1.Panel2.Controls.Add(this.labelBoxTarjeta);
            this.splitContainer1.Panel2.Controls.Add(this.labelBoxCP);
            this.splitContainer1.Panel2.Controls.Add(this.labelBoxUso);
            this.splitContainer1.Panel2.Controls.Add(this.labelBoxPago);
            this.splitContainer1.Panel2.Controls.Add(this.labelBoxRfc);
            this.splitContainer1.Size = new System.Drawing.Size(309, 530);
            this.splitContainer1.SplitterDistance = 35;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos Fiscales";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(318, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel1MinSize = 35;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.visorImagenes);
            this.splitContainer2.Size = new System.Drawing.Size(399, 530);
            this.splitContainer2.SplitterDistance = 35;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.00547F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.95271F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.12128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.92054F));
            this.tableLayoutPanel2.Controls.Add(this.btnFacturar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnObtener, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCompletar, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(399, 35);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnFacturar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnFacturar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnFacturar.Location = new System.Drawing.Point(185, 3);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(102, 29);
            this.btnFacturar.TabIndex = 4;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnCompletar
            // 
            this.btnCompletar.BackColor = System.Drawing.Color.SkyBlue;
            this.btnCompletar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCompletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCompletar.Location = new System.Drawing.Point(293, 3);
            this.btnCompletar.Name = "btnCompletar";
            this.btnCompletar.Size = new System.Drawing.Size(103, 29);
            this.btnCompletar.TabIndex = 3;
            this.btnCompletar.Text = "Completar";
            this.btnCompletar.UseVisualStyleBackColor = false;
            this.btnCompletar.Click += new System.EventHandler(this.btnCompletar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ticket";
            // 
            // btnObtener
            // 
            this.btnObtener.BackColor = System.Drawing.Color.Gold;
            this.btnObtener.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnObtener.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnObtener.Location = new System.Drawing.Point(86, 3);
            this.btnObtener.Name = "btnObtener";
            this.btnObtener.Size = new System.Drawing.Size(93, 29);
            this.btnObtener.TabIndex = 2;
            this.btnObtener.Text = "Obtener";
            this.btnObtener.UseVisualStyleBackColor = false;
            this.btnObtener.Click += new System.EventHandler(this.btnObtener_Click);
            // 
            // visorImagenes
            // 
            this.visorImagenes.AnimateGIF = false;
            this.visorImagenes.BackColor = System.Drawing.Color.Black;
            this.visorImagenes.BackgroundImage = null;
            this.visorImagenes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.visorImagenes.ContinuousViewMode = true;
            this.visorImagenes.Cursor = System.Windows.Forms.Cursors.Default;
            this.visorImagenes.DisplayQuality = GdPicture.DisplayQuality.DisplayQualityBicubicHQ;
            this.visorImagenes.DisplayQualityAuto = false;
            this.visorImagenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visorImagenes.DocumentAlignment = GdPicture.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
            this.visorImagenes.DocumentPosition = GdPicture.ViewerDocumentPosition.DocumentPositionMiddleCenter;
            this.visorImagenes.EnabledProgressBar = true;
            this.visorImagenes.EnableMenu = true;
            this.visorImagenes.EnableMouseWheel = true;
            this.visorImagenes.ForceScrollBars = false;
            this.visorImagenes.ForceTemporaryModeForImage = false;
            this.visorImagenes.ForceTemporaryModeForPDF = false;
            this.visorImagenes.ForeColor = System.Drawing.Color.Black;
            this.visorImagenes.Gamma = 1F;
            this.visorImagenes.HQAnnotationRendering = true;
            this.visorImagenes.IgnoreDocumentResolution = false;
            this.visorImagenes.KeepDocumentPosition = false;
            this.visorImagenes.Location = new System.Drawing.Point(0, 0);
            this.visorImagenes.LockViewer = false;
            this.visorImagenes.MagnifierHeight = 90;
            this.visorImagenes.MagnifierWidth = 160;
            this.visorImagenes.MagnifierZoomX = 2F;
            this.visorImagenes.MagnifierZoomY = 2F;
            this.visorImagenes.MouseButtonForMouseMode = GdPicture.MouseButton.MouseButtonLeft;
            this.visorImagenes.MouseMode = GdPicture.ViewerMouseMode.MouseModePan;
            this.visorImagenes.MouseWheelMode = GdPicture.ViewerMouseWheelMode.MouseWheelModeZoom;
            this.visorImagenes.Name = "visorImagenes";
            this.visorImagenes.OptimizeDrawingSpeed = false;
            this.visorImagenes.PdfDisplayFormField = true;
            this.visorImagenes.PdfEnableLinks = true;
            this.visorImagenes.PDFShowDialogForPassword = true;
            this.visorImagenes.RectBorderColor = System.Drawing.Color.Black;
            this.visorImagenes.RectBorderSize = 1;
            this.visorImagenes.RectIsEditable = true;
            this.visorImagenes.RegionsAreEditable = true;
            this.visorImagenes.ScrollBars = true;
            this.visorImagenes.ScrollLargeChange = ((short)(50));
            this.visorImagenes.ScrollSmallChange = ((short)(1));
            this.visorImagenes.SilentMode = true;
            this.visorImagenes.Size = new System.Drawing.Size(399, 494);
            this.visorImagenes.TabIndex = 0;
            this.visorImagenes.Zoom = 1D;
            this.visorImagenes.ZoomCenterAtMousePosition = false;
            this.visorImagenes.ZoomMode = GdPicture.ViewerZoomMode.ZoomMode100;
            this.visorImagenes.ZoomStep = 25;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(723, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label10);
            this.splitContainer3.Panel1MinSize = 35;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(174, 530);
            this.splitContainer3.SplitterDistance = 35;
            this.splitContainer3.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 25);
            this.label10.TabIndex = 2;
            this.label10.Text = "Texto de Ticket";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.txtBoxOCR);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.textBox2);
            this.splitContainer4.Size = new System.Drawing.Size(174, 491);
            this.splitContainer4.SplitterDistance = 237;
            this.splitContainer4.SplitterWidth = 1;
            this.splitContainer4.TabIndex = 0;
            // 
            // txtBoxOCR
            // 
            this.txtBoxOCR.AcceptsReturn = true;
            this.txtBoxOCR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxOCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxOCR.Location = new System.Drawing.Point(0, 0);
            this.txtBoxOCR.Multiline = true;
            this.txtBoxOCR.Name = "txtBoxOCR";
            this.txtBoxOCR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxOCR.Size = new System.Drawing.Size(174, 237);
            this.txtBoxOCR.TabIndex = 0;
            this.txtBoxOCR.Text = "Texto de barra presente en el ticket";
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(174, 253);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Códigos de barras presentes en el ticket";
            // 
            // labelBoxDireccion
            // 
            this.labelBoxDireccion.AllowResizeTextBox = false;
            this.labelBoxDireccion.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.labelBoxDireccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBoxDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoxDireccion.Informacion = null;
            this.labelBoxDireccion.Location = new System.Drawing.Point(0, 431);
            this.labelBoxDireccion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.labelBoxDireccion.Multiline = true;
            this.labelBoxDireccion.Name = "labelBoxDireccion";
            this.labelBoxDireccion.Size = new System.Drawing.Size(309, 136);
            this.labelBoxDireccion.TabIndex = 13;
            this.labelBoxDireccion.Texto = "Dirección:";
            // 
            // labelBoxNombre
            // 
            this.labelBoxNombre.AllowResizeTextBox = false;
            this.labelBoxNombre.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.labelBoxNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBoxNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoxNombre.Informacion = null;
            this.labelBoxNombre.Location = new System.Drawing.Point(0, 295);
            this.labelBoxNombre.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.labelBoxNombre.Multiline = true;
            this.labelBoxNombre.Name = "labelBoxNombre";
            this.labelBoxNombre.Size = new System.Drawing.Size(309, 136);
            this.labelBoxNombre.TabIndex = 12;
            this.labelBoxNombre.Texto = "Nombre:";
            // 
            // labelBoxTarjeta
            // 
            this.labelBoxTarjeta.AllowResizeTextBox = false;
            this.labelBoxTarjeta.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.labelBoxTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBoxTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoxTarjeta.Informacion = null;
            this.labelBoxTarjeta.Location = new System.Drawing.Point(0, 236);
            this.labelBoxTarjeta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.labelBoxTarjeta.Multiline = false;
            this.labelBoxTarjeta.Name = "labelBoxTarjeta";
            this.labelBoxTarjeta.Size = new System.Drawing.Size(309, 59);
            this.labelBoxTarjeta.TabIndex = 11;
            this.labelBoxTarjeta.Texto = "Tarjeta:";
            // 
            // labelBoxCP
            // 
            this.labelBoxCP.AllowResizeTextBox = false;
            this.labelBoxCP.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.labelBoxCP.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBoxCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoxCP.Informacion = null;
            this.labelBoxCP.Location = new System.Drawing.Point(0, 177);
            this.labelBoxCP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.labelBoxCP.Multiline = false;
            this.labelBoxCP.Name = "labelBoxCP";
            this.labelBoxCP.Size = new System.Drawing.Size(309, 59);
            this.labelBoxCP.TabIndex = 10;
            this.labelBoxCP.Texto = "CP:";
            // 
            // labelBoxUso
            // 
            this.labelBoxUso.AllowResizeTextBox = false;
            this.labelBoxUso.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.labelBoxUso.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBoxUso.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoxUso.Informacion = null;
            this.labelBoxUso.Location = new System.Drawing.Point(0, 118);
            this.labelBoxUso.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.labelBoxUso.Multiline = false;
            this.labelBoxUso.Name = "labelBoxUso";
            this.labelBoxUso.Size = new System.Drawing.Size(309, 59);
            this.labelBoxUso.TabIndex = 9;
            this.labelBoxUso.Texto = "Uso:";
            // 
            // labelBoxPago
            // 
            this.labelBoxPago.AllowResizeTextBox = false;
            this.labelBoxPago.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.labelBoxPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBoxPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoxPago.Informacion = null;
            this.labelBoxPago.Location = new System.Drawing.Point(0, 59);
            this.labelBoxPago.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.labelBoxPago.Multiline = false;
            this.labelBoxPago.Name = "labelBoxPago";
            this.labelBoxPago.Size = new System.Drawing.Size(309, 59);
            this.labelBoxPago.TabIndex = 8;
            this.labelBoxPago.Texto = "Pago:";
            // 
            // labelBoxRfc
            // 
            this.labelBoxRfc.AllowResizeTextBox = false;
            this.labelBoxRfc.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.labelBoxRfc.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBoxRfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoxRfc.Informacion = null;
            this.labelBoxRfc.Location = new System.Drawing.Point(0, 0);
            this.labelBoxRfc.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.labelBoxRfc.Multiline = false;
            this.labelBoxRfc.Name = "labelBoxRfc";
            this.labelBoxRfc.Size = new System.Drawing.Size(309, 59);
            this.labelBoxRfc.TabIndex = 7;
            this.labelBoxRfc.Texto = "RFC:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Contabee Captura";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statuLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private GdPicture.GdViewer visorImagenes;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TextBox txtBoxOCR;
        private System.Windows.Forms.TextBox textBox2;
        private Controls.LabelBox labelBoxDireccion;
        private Controls.LabelBox labelBoxNombre;
        private Controls.LabelBox labelBoxTarjeta;
        private Controls.LabelBox labelBoxCP;
        private Controls.LabelBox labelBoxUso;
        private Controls.LabelBox labelBoxPago;
        private Controls.LabelBox labelBoxRfc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnObtener;
        private System.Windows.Forms.Button btnCompletar;
        private System.Windows.Forms.Button btnFacturar;
    }
}

