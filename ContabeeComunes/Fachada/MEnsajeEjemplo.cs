using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger;

namespace ContabeeComunes.Fachada
{
    public class MensajeEjemplo: ITinyMessage
    {
        public string Dato { get; set; }

        public object Sender { get; set; }
    }
}
