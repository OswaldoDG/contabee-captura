using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeComunes
{
    public class Constantes
    {
        public const string APPVERSION = "1.0.0";   
        public const string GDPARAM = "A1189766972AA998211161A2A92193218";
    }

    /// <summary>
    /// Tpos de notificaciones disponibles. 
    /// </summary>
    public enum TipoNotificacion
    {
        Neutra,
        Info,
        Alerta,
        Error
    }   
}
