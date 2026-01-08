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
        Ninguno = 1,

        /// <summary>
        /// La imagen no tien la calidad o dato suficientes.
        /// </summary>
        ImagenDeficiente = 2,

        /// <summary>
        /// La imagen no contiene datos fiscales.
        /// </summary>
        ImagenErronea = 3,

        /// <summary>
        /// La imagen enviada fue reportada como abuso.
        /// </summary>
        Abuso = 4,

        /// <summary>
        /// El numero de reintentos ha sido superado el maximo permitido.
        /// </summary>
        MaximoIntentosSuperado = 5,

        /// <summary>
        /// No es posible reprogramar debido a que excede el final del mes.
        /// </summary>
        ReprogramacionFueraRango = 6,

        /// <summary>
        /// El portal de generación de facturas require datos privados de o inicio de sesión.
        /// </summary>
        PortalPrivado = 7,

        /// <summary>
        /// Ticket enviado fuera de tiempo.
        /// </summary>
        Extemporaneo = 8,

        /// <summary>
        /// Otro error de procesamiento.
        /// </summary>
        OtroError = 100
    }


    public enum TipoFuenteProcesamiento
    {
        /// <summary>
        /// EL CFDI no pudo obtenerse por algún error.
        /// </summary>
        Ninguno = 1,

        /// <summary>
        /// El CFDI se obtiene de una página web.
        /// </summary>
        Web = 2,

        /// <summary>
        /// El CFDI se obtiene vía email.
        /// </summary>
        Email = 3,

        /// <summary>
        /// El CFDI se obtiene vía WhatsApp o similar.
        /// </summary>
        WhatsApp = 4,

        /// <summary>
        /// El CFDI se obtiene vía WhatsApp o similar.
        /// </summary>
        Telefono = 5
    }

}
