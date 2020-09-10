using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.DotNetCoreIocService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLocator(this IServiceCollection services)
        {
            services.AddScoped<IServiceLocator, DotNetCoreServiceLocator>();
            return services;
        }
    }
}