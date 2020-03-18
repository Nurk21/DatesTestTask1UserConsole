using DatesTestTaskUserConsole.UserInputHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;

namespace DatesTestTaskUserConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            var serviceProvider = DependencyInjector.Setup(new ServiceCollection(), builder.Build()).BuildServiceProvider();

            var processing = serviceProvider.GetService<IProcessing>();

            processing.ProcessingUserInput();           
            Console.ReadKey();
        }
    }
}
