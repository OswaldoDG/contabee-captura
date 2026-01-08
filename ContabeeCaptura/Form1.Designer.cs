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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelBlob = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPosSplit1 = new System.Windows.Forms.Button();
            this.btnPosSplit2 = new System.Windows.Forms.Button();
            this.btnPosSplit3 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctlOCR2 = new ContabeeCaptura.Controls.CtlOCR();
            this.ctlDatosFiscales2 = new ContabeeCaptura.Controls.CtlDatosFiscales();
            this.ctlImagen2 = new ContabeeCaptura.Controls.CtlImagen();
            this.ctlFacturacion2 = new ContabeeCaptura.Controls.CtlFacturacion();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 730);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1283, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuLabel
            // 
            this.statuLabel.Image = global::ContabeeCaptura.Properties.Resources.alert_info_icon;
            this.statuLabel.Name = "statuLabel";
            this.statuLabel.Size = new System.Drawing.Size(20, 20);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1283, 730);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 339F));
            this.tableLayoutPanel1.Controls.Add(this.labelBlob, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSiguiente, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1283, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelBlob
            // 
            this.labelBlob.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBlob.AutoSize = true;
            this.labelBlob.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlob.Location = new System.Drawing.Point(480, 22);
            this.labelBlob.Name = "labelBlob";
            this.labelBlob.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelBlob.Size = new System.Drawing.Size(275, 25);
            this.labelBlob.TabIndex = 1;
            this.labelBlob.Text = "PROCESO DE CAPTURA";
            this.labelBlob.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSiguiente.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSiguiente.Location = new System.Drawing.Point(1017, 13);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(192, 43);
            this.btnSiguiente.TabIndex = 3;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnPosSplit1);
            this.flowLayoutPanel1.Controls.Add(this.btnPosSplit2);
            this.flowLayoutPanel1.Controls.Add(this.btnPosSplit3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(259, 47);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnPosSplit1
            // 
            this.btnPosSplit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPosSplit1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPosSplit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosSplit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnPosSplit1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnPosSplit1.Location = new System.Drawing.Point(3, 3);
            this.btnPosSplit1.Name = "btnPosSplit1";
            this.btnPosSplit1.Size = new System.Drawing.Size(80, 40);
            this.btnPosSplit1.TabIndex = 0;
            this.btnPosSplit1.Text = "1";
            this.btnPosSplit1.UseVisualStyleBackColor = false;
            // 
            // btnPosSplit2
            // 
            this.btnPosSplit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPosSplit2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPosSplit2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosSplit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnPosSplit2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnPosSplit2.Location = new System.Drawing.Point(89, 3);
            this.btnPosSplit2.Name = "btnPosSplit2";
            this.btnPosSplit2.Size = new System.Drawing.Size(80, 40);
            this.btnPosSplit2.TabIndex = 1;
            this.btnPosSplit2.Text = "2";
            this.btnPosSplit2.UseVisualStyleBackColor = false;
            // 
            // btnPosSplit3
            // 
            this.btnPosSplit3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPosSplit3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPosSplit3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosSplit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnPosSplit3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnPosSplit3.Location = new System.Drawing.Point(175, 3);
            this.btnPosSplit3.Name = "btnPosSplit3";
            this.btnPosSplit3.Size = new System.Drawing.Size(80, 40);
            this.btnPosSplit3.TabIndex = 2;
            this.btnPosSplit3.Text = "3";
            this.btnPosSplit3.UseVisualStyleBackColor = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ctlFacturacion2);
            this.splitContainer2.Size = new System.Drawing.Size(1283, 659);
            this.splitContainer2.SplitterDistance = 423;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 659);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer3);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(415, 630);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ctlOCR2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ctlDatosFiscales2);
            this.splitContainer3.Size = new System.Drawing.Size(409, 624);
            this.splitContainer3.SplitterDistance = 286;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctlImagen2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(415, 630);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Imagen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctlOCR2
            // 
            this.ctlOCR2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlOCR2.Location = new System.Drawing.Point(0, 0);
            this.ctlOCR2.Margin = new System.Windows.Forms.Padding(4);
            this.ctlOCR2.Name = "ctlOCR2";
            this.ctlOCR2.Size = new System.Drawing.Size(409, 286);
            this.ctlOCR2.TabIndex = 0;
            // 
            // ctlDatosFiscales2
            // 
            this.ctlDatosFiscales2.AutoScroll = true;
            this.ctlDatosFiscales2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDatosFiscales2.Location = new System.Drawing.Point(0, 0);
            this.ctlDatosFiscales2.Margin = new System.Windows.Forms.Padding(4);
            this.ctlDatosFiscales2.Name = "ctlDatosFiscales2";
            this.ctlDatosFiscales2.Size = new System.Drawing.Size(409, 337);
            this.ctlDatosFiscales2.TabIndex = 0;
            // 
            // ctlImagen2
            // 
            this.ctlImagen2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlImagen2.Location = new System.Drawing.Point(3, 3);
            this.ctlImagen2.Margin = new System.Windows.Forms.Padding(4);
            this.ctlImagen2.Name = "ctlImagen2";
            this.ctlImagen2.Size = new System.Drawing.Size(409, 624);
            this.ctlImagen2.TabIndex = 0;
            // 
            // ctlFacturacion2
            // 
            this.ctlFacturacion2.AutoSize = true;
            this.ctlFacturacion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFacturacion2.Location = new System.Drawing.Point(0, 0);
            this.ctlFacturacion2.Margin = new System.Windows.Forms.Padding(2);
            this.ctlFacturacion2.Name = "ctlFacturacion2";
            this.ctlFacturacion2.Size = new System.Drawing.Size(856, 659);
            this.ctlFacturacion2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1283, 755);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statuLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelBlob;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnPosSplit1;
        private System.Windows.Forms.Button btnPosSplit2;
        private System.Windows.Forms.Button btnPosSplit3;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Controls.CtlOCR ctlOCR2;
        private Controls.CtlDatosFiscales ctlDatosFiscales2;
        private Controls.CtlImagen ctlImagen2;
        private Controls.CtlFacturacion ctlFacturacion2;
    }
}

