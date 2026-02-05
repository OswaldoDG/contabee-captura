using System;

namespace ContabeeComunes.Bitacora
{    /// <summary>
     /// Bitacora de todos los errores que lanza la aplicación.
     /// </summary>
    public interface IServicioBitacora
    {
        /// <summary>
        /// Log de Errores y excepciones de la Aplicación.
        /// </summary>
        /// <param name="mensaje">"Mensaje indicando el lugar donde se presenta el error."</param>
        /// <param name="exception">Exception producida.</param>
        void LogError(string mensaje, Exception exception);

        /// <summary>
        /// Log de Información lo que está ocurriendo en la Aplicación.
        /// </summary>
        /// <param name="mensaje">"Registra el procesdo que está ocurriendo."</param>
        void LogInfo(string mensaje);
    }
}
