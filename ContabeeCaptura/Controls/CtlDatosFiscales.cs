using ContabeeCaptura.Fachada;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
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
    public partial class CtlDatosFiscales : UserControl
    {
        private IHubEventos _hub;
        private Guid _subDatos;
        private Guid _subClear;
        public CtlDatosFiscales()
        {
            InitializeComponent();
            this.HandleDestroyed += (s, e) => {
                if (_hub != null)
                {
                    _hub.Desuscribir(_subDatos);
                    _hub.Desuscribir(_subClear);
                }
            };
        }

        public void Configurar(IHubEventos hub)
        {
            _hub = hub;
            _subDatos = _hub.Suscribir<DatosFiscalesMensaje>(OnDatosRecibidos);
            _subClear = _hub.Suscribir<MensajeClear>(OnLimpiarUI);
        }

        private void OnLimpiarUI(MensajeClear msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnLimpiarUI(msg)));
                return;
            }

            textBoxRFC.Text = "";
            textBoxPago.Text = "";
            textBoxUso.Text = "";
            textBoxCP.Text = "";
            textBoxTarjeta.Text = "";
            textBoxNombre.Text = "";
            textBoxDomicilio.Text = "";
        }

        private void OnDatosRecibidos(DatosFiscalesMensaje msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnDatosRecibidos(msg)));
                return;
            }

            if (msg.Datos != null)
            {
                textBoxRFC.Text = msg.Datos.Rfc;
                textBoxPago.Text = msg.Datos.FormaPago;
                textBoxUso.Text = msg.Datos.UsoFactura;
                textBoxCP.Text = msg.Datos.CodigoPostal;
                textBoxTarjeta.Text = msg.Datos.TerminacionPago;
                textBoxNombre.Text = msg.Datos.Denominacion;
                textBoxDomicilio.Text = msg.Datos.Direccion;
            }
        }

    }
}
