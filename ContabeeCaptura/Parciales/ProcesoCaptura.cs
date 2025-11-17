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
            return ContabeeComunes.Constantes.GDPARAMS.Replace("A", "4");
        }


    }
}
