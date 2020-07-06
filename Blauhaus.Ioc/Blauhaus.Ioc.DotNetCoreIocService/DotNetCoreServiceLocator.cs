using System;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.DotNetCoreIocService
{
    public class DotNetCoreServiceLocator : IServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public DotNetCoreServiceLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}