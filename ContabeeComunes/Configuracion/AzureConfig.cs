namespace ContabeeComunes.Configuracion
{
    /// <summary>
    /// Parámetros de configuración para Computer Vision de Azur (OCR).
    /// </summary>
    public class AzureConfig
    {
        /// <summary>
        /// Endpoint para realizar el procesamiento.
        /// </summary>
        public string Endpoint { get; set; }
        /// <summary>
        /// Llave para realizar el procesamiento.
        /// </summary>
        public string Key { get; set; }
    }
}
