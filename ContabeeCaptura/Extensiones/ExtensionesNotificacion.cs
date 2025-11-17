using ContabeeComunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ContabeeCaptura.Extensiones
{
    public static class ExtensionesNotificacion
    {
        public static void MensajeEnLabel(this Label label, string mensaje, TipoNotificacion tipo)
        {
            switch(tipo)
                {
                case TipoNotificacion.Neutra:
                    label.ForeColor = System.Drawing.SystemColors.ControlText;
                    label.BackColor = System.Drawing.SystemColors.Control;
                    break;

                case TipoNotificacion.Info:
                    label.BackColor = System.Drawing.Color.LightBlue;
                    label.ForeColor = System.Drawing.Color.Black;
                    break;
                
                case TipoNotificacion.Alerta:
                    label.BackColor = System.Drawing.Color.Gold;
                    label.ForeColor = System.Drawing.Color.Black;
                    break;
                
                case TipoNotificacion.Error:
                    label.BackColor = System.Drawing.Color.Red;
                    label.ForeColor = System.Drawing.Color.White;
                    break;
            }

            label.Text = mensaje;
        }

        public static void UpdateStatus(ToolStripStatusLabel statusLabel, string text)
        {
            
        }

        public static void Mensaje(this ToolStripStatusLabel label, string mensaje, TipoNotificacion tipo)
        {
            System.Drawing.Image img = global::ContabeeCaptura.Properties.Resources.alert_info_icon;

            switch (tipo)
            {
                case TipoNotificacion.Neutra:
                    img = global::ContabeeCaptura.Properties.Resources.alert_info_icon;
                    break;

                case TipoNotificacion.Info:
                    img = global::ContabeeCaptura.Properties.Resources.alert_ok_icon;
                    break;

                case TipoNotificacion.Alerta:
                    img = global::ContabeeCaptura.Properties.Resources.alert_warning_icon;
                    break;

                case TipoNotificacion.Error:
                    img = global::ContabeeCaptura.Properties.Resources.alert_error_icon;
                    break;
            }

            if (label.GetCurrentParent().InvokeRequired)
            {
                label.GetCurrentParent().Invoke(new Action(() => label.Text = mensaje));
                label.GetCurrentParent().Invoke(new Action(() => label.Image = img));
            }
            else
            {
                label.Text = mensaje;
                label.Image = img;
            }
          
        }
    }
}
