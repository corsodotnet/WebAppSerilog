using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WebAppDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                //.WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Application Starting Up....");
                //Log.Warning();
                //Log.Debug();
                //Log.Error();
                //Log.Fatal();
                CreateHostBuilder(args).Build().Run();

            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex.Message, "Application FAILED to starting up! ");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
