using ContabeeApi.Modelos;
using ContabeeApi.Modelos.Captura;
using ContabeeCaptura.Extensiones;
using ContabeeComunes;
using ContabeeComunes.Eventos;
using ContabeeComunes.RespuestaApi;
using ContabeeComunes.Sesion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TinyMessenger;

namespace ContabeeCaptura.Forms
{
    public partial class CompletarCaptura : Form
    {
        private readonly IHubEventos _hubEventos;
        private readonly ITinyMessengerHub _hub;
        private readonly ServicioSesion _servicioSesion;
        public List<string> comprobantesPath = new List<string>();
        public CompletarCapturaPagina finalizada { get; set; }
        public CompletarCaptura(IServicioSesion servicioSesion, ITinyMessengerHub hub, IHubEventos hubEventos)
        {
            _servicioSesion = servicioSesion as ServicioSesion;
            _hubEventos = hubEventos;
            _hub = hub;
            InitializeComponent();
            SetupUI();
        }

        /// <summary>
        /// En este setup se configuran los elementos de la UI  
        /// </summary>
        private void SetupUI()
        {
            this.Text = $"Contabee Capture V{Constantes.APPVERSION} - {_servicioSesion.ObtenerNombreUsuario()}";
            this.statuLabel.Text = "ContabeeCapture V" + Constantes.APPVERSION;
            this.statuLabel.Image = global::ContabeeCaptura.Properties.Resources.alert_info_icon;
        }

        /// <summary>
        /// En este setup se configuran los hooks de eventos y servicios.
        /// </summary>
        private void SetupHooks()
        {
            _hub.Subscribe<NotificacionUIEvent>(evento =>
            {
                this.statuLabel.Mensaje(evento.Mensaje, evento.Tipo);
            });
        }

        private void CompletarCaptura_Load(object sender, EventArgs e)
        {
            SetupHooks();
        }

        private void btnComprobantes_Click(object sender, EventArgs e)
        {
            if (comprobantesPath.Count >= 2)
            {
                _hubEventos.PublicarNotificacionUI(this, "Seleccione únicamente 2 comprobantes (PDF o XML)", TipoNotificacion.Alerta);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Archivos permitidos|*.pdf;*.jpg;*.jpeg;*.png;*.xml;*.html;*.txt;*.json;*.csv";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        if (comprobantesPath.Count >= 2)
                        {
                            _hubEventos.PublicarNotificacionUI(this, "Solo se permiten 2 comprobantes (PDF o XML).", TipoNotificacion.Alerta);
                            break;
                        }

                        comprobantesPath.Add(file);

                        FileInfo fi = new FileInfo(file);

                        ListViewItem item = new ListViewItem(fi.Name);

                        listViewComprobantes.Items.Add(item);
                    }
                }
            }
        }

        private void BtnRemoverComprobante_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            finalizada = new CompletarCapturaPagina()
            {
                Reprogramar = cbxReprogramar.Text.Equals("Reprogramar", StringComparison.OrdinalIgnoreCase) ? false : true,
                Motivo = (MotivoEstado)Enum.Parse(typeof(MotivoEstado), cbxMotivo.Text),
                TipoFuente = (TipoFuenteProcesamiento)Enum.Parse(typeof(TipoFuenteProcesamiento), cbxTipoFuente.Text),
                Comentario = txtBxComentario.Text,
                SinXml = chxXml.Checked,
                SinPdf = chxPdf.Checked,
                Url = txtBxUrl.Text,
                TieneCaptcha = cbxTieneCaptcha.Checked,
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
