namespace ContabeeCaptura.Controls
{
    partial class CtlFacturacion
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.navegador = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFecha = new System.Windows.Forms.Button();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUUID = new System.Windows.Forms.TextBox();
            this.chkBoxXML = new System.Windows.Forms.CheckBox();
            this.chxBoxPDF = new System.Windows.Forms.CheckBox();
            this.btnUUID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navegador)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.navegador, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(830, 505);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxTotal, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnFinalizar, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 464);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(824, 38);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(217, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "TICKET MONTO TOTAL: $";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxTotal.Location = new System.Drawing.Point(226, 6);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(495, 26);
            this.textBoxTotal.TabIndex = 38;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinalizar.BackColor = System.Drawing.Color.SkyBlue;
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnFinalizar.Location = new System.Drawing.Point(726, 2);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(96, 34);
            this.btnFinalizar.TabIndex = 5;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // navegador
            // 
            this.navegador.AllowExternalDrop = true;
            this.navegador.CreationProperties = null;
            this.navegador.DefaultBackgroundColor = System.Drawing.Color.White;
            this.navegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navegador.Location = new System.Drawing.Point(2, 102);
            this.navegador.Margin = new System.Windows.Forms.Padding(2);
            this.navegador.Name = "navegador";
            this.navegador.Size = new System.Drawing.Size(826, 357);
            this.navegador.TabIndex = 0;
            this.navegador.ZoomFactor = 1D;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(826, 96);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnFecha, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFecha, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUUID, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkBoxXML, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chxBoxPDF, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUUID, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(822, 44);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnFecha
            // 
            this.btnFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnFecha.Location = new System.Drawing.Point(790, 8);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(28, 27);
            this.btnFecha.TabIndex = 38;
            this.btnFecha.Text = "⧉";
            this.btnFecha.UseVisualStyleBackColor = true;
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxFecha.Location = new System.Drawing.Point(600, 9);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.Size = new System.Drawing.Size(142, 26);
            this.textBoxFecha.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(479, 12);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "FECHA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxUUID
            // 
            this.textBoxUUID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxUUID.Location = new System.Drawing.Point(244, 9);
            this.textBoxUUID.Name = "textBoxUUID";
            this.textBoxUUID.Size = new System.Drawing.Size(142, 26);
            this.textBoxUUID.TabIndex = 34;
            // 
            // chkBoxXML
            // 
            this.chkBoxXML.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkBoxXML.AutoSize = true;
            this.chkBoxXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chkBoxXML.Location = new System.Drawing.Point(69, 10);
            this.chkBoxXML.Margin = new System.Windows.Forms.Padding(2);
            this.chkBoxXML.Name = "chkBoxXML";
            this.chkBoxXML.Size = new System.Drawing.Size(64, 24);
            this.chkBoxXML.TabIndex = 1;
            this.chkBoxXML.Text = "XML";
            this.chkBoxXML.UseVisualStyleBackColor = true;
            // 
            // chxBoxPDF
            // 
            this.chxBoxPDF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chxBoxPDF.AutoSize = true;
            this.chxBoxPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chxBoxPDF.Location = new System.Drawing.Point(2, 10);
            this.chxBoxPDF.Margin = new System.Windows.Forms.Padding(2);
            this.chxBoxPDF.Name = "chxBoxPDF";
            this.chxBoxPDF.Size = new System.Drawing.Size(63, 24);
            this.chxBoxPDF.TabIndex = 0;
            this.chxBoxPDF.Text = "PDF";
            this.chxBoxPDF.UseVisualStyleBackColor = true;
            // 
            // btnUUID
            // 
            this.btnUUID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUUID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnUUID.Location = new System.Drawing.Point(434, 8);
            this.btnUUID.Name = "btnUUID";
            this.btnUUID.Size = new System.Drawing.Size(39, 27);
            this.btnUUID.TabIndex = 35;
            this.btnUUID.Text = "⧉";
            this.btnUUID.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(138, 12);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "UUID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel4.Controls.Add(this.btnBuscar, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBoxURL, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(820, 42);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(660, 5);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(158, 32);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "URL:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxURL
            // 
            this.textBoxURL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxURL.Location = new System.Drawing.Point(81, 8);
            this.textBoxURL.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(551, 26);
            this.textBoxURL.TabIndex = 4;
            // 
            // CtlFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CtlFacturacion";
            this.Size = new System.Drawing.Size(830, 505);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navegador)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Microsoft.Web.WebView2.WinForms.WebView2 navegador;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chxBoxPDF;
        private System.Windows.Forms.CheckBox chkBoxXML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUUID;
        private System.Windows.Forms.Button btnUUID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTotal;
    }
}
