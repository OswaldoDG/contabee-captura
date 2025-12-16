using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.XML
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServicioXML
    {
        (string UUID, string Fecha) ExtraerInfoCFDI(string rutaXml);
    }
}
