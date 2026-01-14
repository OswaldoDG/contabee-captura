using ContabeeApi.Modelos.Captura;
using ContabeeCaptura.Forms;
using ContabeeComunes;
using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabeeCaptura
{
    /// <summary>
    /// Aquir irán todas las definiciones para el proceso de captura.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// REgersa la licencia de gdpicture.
        /// </summary>
        /// <returns></returns>
        private string GetGDlic()
        {
            return ContabeeComunes.Constantes.GDPARAM.Replace("A", "4");
        }

    }
}
