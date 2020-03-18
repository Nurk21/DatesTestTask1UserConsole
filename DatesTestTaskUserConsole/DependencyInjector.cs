using DatesTestTaskUserConsole.Models;
using DatesTestTaskUserConsole.UserInputHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace DatesTestTaskUserConsole
{
    public static class DependencyInjector
    {       
        public static IServiceCollection Setup(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingSection = configuration.GetSection("AppSettings");
            return services.ConfigureHttpServices(appSettingSection);
        }

        private static IServiceCollection ConfigureHttpServices(this IServiceCollection services, IConfigurationSection appSettingSection)
        {
            services.AddHttpClient("API", client =>
            {
                client.BaseAddress = new Uri(appSettingSection.GetValue<string>("ServerAPI"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<IDateService, DateService>("API");
            services.AddScoped<IProcessing, Processing>();
            return services;
        }
    }
}
