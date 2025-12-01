using ContabeeApi.Modelos.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.Modelos.Captura
{
    public class PaginaTrabajoCaptura
    {
        /// <summary>
        /// Identificador único de la página de trabajo.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ID del lote al que pertenece la página.
        /// </summary>
        public long LoteId { get; set; }

        /// <summary>
        /// Ruta de almacenamiento de la pagina.
        /// </summary>
        public string Ruta { get; set; }

        /// <summary>
        /// Tipo del archivo a preocesar.
        /// </summary>
        public FileType TipoArchivo { get; set; }

        /// <summary>
        /// Rfc asociado.
        /// </summary>
        public string Rfc { get; set; }

        /// <summary>
        /// Nombre o razon social.
        /// </summary>
        public string Denominacion { get; set; }

        /// <summary>
        /// Regimen fiscal del asociado.
        /// </summary>
        public string RegimenFiscal { get; set; }

        /// <summary>
        /// Uso de la factura.
        /// </summary>
        public string UsoFactura { get; set; }

        /// <summary>
        /// Forma de pago.
        /// </summary>
        public string FormaPago { get; set; }

        /// <summary>
        /// Medio de pago.
        /// </summary>
        public string CodigoPostal { get; set; }

        /// <summary>
        /// Direccion postal.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Terminacion de la forma de pago.
        /// </summary>
        public string TerminacionPago { get; set; }

        /// <summary>
        /// Comentarios del lote.
        /// </summary>
        public string Comentarios { get; set; }
    }
}
