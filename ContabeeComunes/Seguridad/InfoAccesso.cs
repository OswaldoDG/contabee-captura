namespace ContabeeComunes.Seguridad
{
    /// <summary>
    /// Datos del acceso a la aplicacion.
    /// </summary>
    public class InfoAccesso
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
     }
}
