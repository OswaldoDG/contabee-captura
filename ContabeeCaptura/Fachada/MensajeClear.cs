using TinyMessenger;

namespace ContabeeCaptura.Fachada
{
    /// <summary>
    /// Este mensaje no tiene payload es solo para limpiar la UI;
    /// </summary>
    public class MensajeClear : ITinyMessage
    {
        public object Sender { get; set; }
    }
}
