using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace FamilyBudgetContext.Host.Public.Api
{
    /// <summary>
    /// Класс запуска приложения.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Метод запуска приложения.
        /// </summary>
        /// <param name="args">Аргументы для запуска приложения.</param>
        /// <returns>Код остановки.</returns>
        public static int Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateLogger();

            try
            {
                Console.WriteLine("Api is start, GoodLuck");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Неожиданное завершение приложения");
                Console.WriteLine($"ОШИБКА{e}");
                return 1;
            }
            finally
            { 
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(w =>
                {
                    w.UseStartup<Startup>();
                })
                .UseSerilog((host, config) =>
                {
                    config.ReadFrom.Configuration(host.Configuration);
                });
    }
}
