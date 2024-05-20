using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Simulation.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // MediatR
            services.AddMediatR(config => {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // HTTP
            services.AddHttpClient("HttpService", client =>
            {
                client.BaseAddress = new Uri(configuration["ExternalApi:BaseAddress"]);
                client.DefaultRequestHeaders.Add("X-API-Key", configuration["ExternalApi:ApiKey"]);
            });

            return services;
        }
    }
}
