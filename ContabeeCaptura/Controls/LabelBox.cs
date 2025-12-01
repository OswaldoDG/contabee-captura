using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabeeCaptura.Controls
{
    public partial class LabelBox : UserControl
    {
        private string _Texto;
        private string _Informacion;
        public bool AllowResizeTextBox { get; set; } = false;
        public LabelBox()
        {
            InitializeComponent();
        }

        [Category("Apariencia")]
        [Description("Texto que se mostrará en el botón principal.")]
        public string Texto
        {
            get { return _Texto; }
            set
            {
                _Texto = value;
                this.label1.Text = value;
            }
        }

        [Category("Apariencia")]
        [Description("Texto que se mostrará en el TextBox principal.")]
        public string Informacion
        {
            get { return _Informacion; }
            set 
            { 
                _Informacion = value;
                this.txtBoxInformacion.Text = value;
            }

        }

        [Category("Custom")]
        [Description("Permite que el TextBox sea multiline.")]
        public bool Multiline
        {
            get => txtBoxInformacion.Multiline;
            set
            {
                txtBoxInformacion.Multiline = value;

                if (value)
                {
                    txtBoxInformacion.ScrollBars = ScrollBars.Vertical;
                    txtBoxInformacion.WordWrap = true;
                }
                else
                {
                    txtBoxInformacion.ScrollBars = ScrollBars.None;
                    txtBoxInformacion.WordWrap = false;
                }

                txtBoxInformacion.Dock = DockStyle.Fill;
            }
        }
    }
}
