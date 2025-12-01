using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.Modelos
{

    public enum MotivoEstado
    {
        /// <summary>
        /// No hay motivo asignado.
        /// </summary>
        Ninguno,

        /// <summary>
        /// La imagen no tien la calidad o dato suficientes.
        /// </summary>
        ImagenDeficiente,

        /// <summary>
        /// La imagen no contiene datos fiscales.
        /// </summary>
        ImagenErronea,

        /// <summary>
        /// La imagen enviada fue reportada como abuso.
        /// </summary>
        Abuso,

        /// <summary>
        /// El numero de reintentos ha sido superado el maximo permitido.
        /// </summary>
        MaximoIntentosSuperado,

        /// <summary>
        /// No es posible reprogramar debido a que excede el final del mes.
        /// </summary>
        ReprogramacionFueraRango,

        /// <summary>
        /// Otro error de procesamiento.
        /// </summary>
        OtroError = 100
    }


    public enum TipoFuenteProcesamiento
    {
        /// <summary>
        /// El CFDI se obtiene de una página web.
        /// </summary>
        Web,

        /// <summary>
        /// El CFDI se obtiene vía email.
        /// </summary>
        Email,

        /// <summary>
        /// El CFDI se obtiene vía WhatsApp o similar.
        /// </summary>
        WhatsApp,

        /// <summary>
        /// El CFDI se obtiene vía WhatsApp o similar.
        /// </summary>
        Telefono
    }

}
