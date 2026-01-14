using ContabeeCaptura.Fachada;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using Serilog.Parsing;
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
    public partial class CtlOCR : UserControl
    {
        private IHubEventos _hub;
        private Guid _subOcr;
        private Guid _subClear; 

        public CtlOCR()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.HandleDestroyed += (s, e) => {
                if (_hub != null)
                {
                    _hub.Desuscribir(_subOcr);
                    _hub.Desuscribir(_subClear);
                }
            };
        }

        public void Configurar(IHubEventos hub)
        {
            _hub = hub;
            _subOcr = _hub.Suscribir<OCRMensaje>(OnResultadoOcr);
            _subClear = _hub.Suscribir<MensajeClear>(OnLimpiarUI);
        }

        private void OnLimpiarUI(MensajeClear msg)
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => OnLimpiarUI(msg))); return; }

            textBoxOCR.Text = string.Empty;
        }

        private void OnResultadoOcr(OCRMensaje msg)
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => OnResultadoOcr(msg))); return; }

            textBoxOCR.Text = msg.TextoDetectado;
        }
    }
}
