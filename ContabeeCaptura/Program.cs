using ContabeeApi;
using ContabeeCaptura.Forms;
using ContabeeCaptura.Parciales;
using ContabeeComunes.Configuracion;
using ContabeeComunes.Eventos;
using ContabeeComunes.Fachada;
using ContabeeComunes.ProxyGenerico;
using ContabeeComunes.Sesion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Windows.Forms;
using TinyMessenger;

namespace ContabeeCaptura
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            // Configuración
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            string logdir = Path.Combine(Path.GetTempPath(), "contabee");   
            if (!Directory.Exists(logdir))
            {
                Directory.CreateDirectory(logdir);
            }
            var tempPath = Path.Combine(logdir, "capture-log.txt");

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .WriteTo.File(tempPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Inyección de dependencias
            var services = new ServiceCollection();

            // Configurar logging con Serilog   
            services.AddLogging(config =>
            {
                config.ClearProviders();
                config.AddSerilog();
            });


            // Configuración de ApiConfig desde appsettings
            services.Configure<ApiConfig>(Configuration.GetSection("ApiConfig"));
            services.Configure<AzureConfig>(Configuration.GetSection("AzureConfig"));


            // Registrar Form1
            services.AddTransient<Form1>();
            services.AddTransient<Login>();
            services.AddTransient<CompletarCaptura>();
            services.AddTransient<BrowserFactura>();
            services.AddSingleton<ITinyMessengerHub, TinyMessengerHub>();
            services.AddSingleton<IHubEventos, HubEventos>();
            services.AddSingleton<IServicioFachada, ServicioFachada>();
            services.AddSingleton<IProxyGenerico, ProxyGenerico>();
            services.AddSingleton< IServicioSesion, ServicioSesion > ();
            services.AddTransient<IApiContabee, ApiContabee>();
            services.AddHttpClient();

            ServiceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Obtener instancia de Form1 desde el contenedor
            var form = ServiceProvider.GetRequiredService<Login>();
            Application.Run(form);
        }
    }
}
