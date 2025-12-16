using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContabeeApi.XML
{
    public class ServicioXML : IServicioXML
    {
        public (string UUID, string Fecha) ExtraerInfoCFDI(string rutaXml)
        {
            rutaXml = "C:\\borrame2\\LectorXML\\LectorXML\\EjemploV4.xml";
            if (!File.Exists(rutaXml)) return (null, null);

            XDocument xmlDoc = XDocument.Load(rutaXml);

            var comprobante = xmlDoc.Root;
            if (comprobante == null) return (null, null);

            string version = comprobante.Attribute("Version")?.Value ?? comprobante.Attribute("version")?.Value;

            if (string.IsNullOrEmpty(version)) return (null, null);

            XNamespace cfdi = version.StartsWith("3")
                ? "http://www.sat.gob.mx/cfd/3"
                : "http://www.sat.gob.mx/cfd/4";

            XNamespace tfd = "http://www.sat.gob.mx/TimbreFiscalDigital";

            string fecha = comprobante.Attribute("Fecha")?.Value;

            var timbre = comprobante
                .Element(cfdi + "Complemento")
                ?.Element(tfd + "TimbreFiscalDigital");

            string uuid = timbre?.Attribute("UUID")?.Value;

            return (uuid, fecha);
        }
    }
}
