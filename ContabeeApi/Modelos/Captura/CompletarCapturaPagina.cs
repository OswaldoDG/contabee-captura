using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.Modelos.Captura
{
    public class CompletarCapturaPagina
    {
        /// <summary>
        /// Identificador único de la página.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Especifica si el proceso debe reprogrmarse pues no ha sido concluido.
        /// </summary>
        public bool Reprogramar { get; set; }

        /// <summary>
        /// En el caso de que la página tenga un error de captura, se puede indicar el motivo de la falla.
        /// </summary>
        public MotivoEstado Motivo { get; set; }

        /// <summary>
        /// Tipo de fuente de procesamiento de la página.
        /// </summary>
        public TipoFuenteProcesamiento TipoFuente { get; set; }

        /// <summary>
        /// Cometario opcional para la captura.
        /// </summary>
        public string Comentario { get; set; } = null;

        /// <summary>
        /// Especifica si no tiene un XML.
        /// </summary>
        public bool SinXml { get; set; }

        /// <summary>
        /// Especifica si no tiene un PDF.
        /// </summary>
        public bool SinPdf { get; set; }

        /// <summary>
        /// URL de la página de captura.
        /// </summary>
        public string Url { get; set; } = null;

        /// <summary>
        /// Especifica si la URL utiliza captcha para realizar la captura.
        /// </summary>
        public bool TieneCaptcha { get; set; }

        /// <summary>
        /// IDentificador único del CFDI.
        /// </summary>
        public string CfdiId { get; set; } = null;

        /// <summary>
        /// Fecha del CFDI.
        /// </summary>
        public DateTime FechaCfdi { get; set; }
    }

}
