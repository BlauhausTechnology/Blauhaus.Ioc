using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.DotNetCoreIocService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLocator(this IServiceCollection services)
        {
            //allows the construction of service locator to be deferred until there is a valid (non-root) serviceProvider available
            services.AddScoped<IServiceLocator>(sp => new DotNetCoreServiceLocator(sp));
            return services;
        }
    }
}