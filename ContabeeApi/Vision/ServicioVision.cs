using ContabeeComunes.Configuracion;
using ContabeeComunes.RespuestaApi;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.Vision
{
    public class ServicioVision : IServicioVision
    {
        private readonly ILogger<ServicioVision> _logger;
        private AzureConfig _azureConfig;


        public ServicioVision(ILogger<ServicioVision> logger, IOptions<AzureConfig> azureConfig)
        {
            _logger = logger;
            _azureConfig = azureConfig.Value;
        }
        public async Task<RespuestaPayload<string>> TextoOCR(Stream imagen)
        {
            RespuestaPayload<string> r = new RespuestaPayload<string>();
            try
            {
                string endpoint = _azureConfig.Endpoint;
                string apiKey = _azureConfig.Key;

                var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(apiKey))
                { Endpoint = endpoint };

                if (imagen.CanSeek)
                    imagen.Position = 0;

                var textHeaders = await client.ReadInStreamAsync(imagen).ConfigureAwait(false);
                string operationId = textHeaders.OperationLocation.Split('/').Last();

                ReadOperationResult resultado;
                do
                {
                    await Task.Delay(500);
                    resultado = await client.GetReadResultAsync(Guid.Parse(operationId));
                }
                while (resultado.Status == OperationStatusCodes.Running ||
                       resultado.Status == OperationStatusCodes.NotStarted);

                var builder = new StringBuilder();

                var pages = resultado.AnalyzeResult.ReadResults;
                foreach (var page in pages)
                {
                    foreach (var line in page.Lines)
                        builder.AppendLine(line.Text);
                }


                var texto = builder.ToString().Trim();
                r.Payload = texto;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            return r;
        }
    }
}
