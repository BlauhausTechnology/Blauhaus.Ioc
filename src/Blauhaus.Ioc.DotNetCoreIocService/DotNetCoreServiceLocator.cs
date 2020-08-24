using System;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.DotNetCoreIocService
{
    public class DotNetCoreServiceLocator : IServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;
        private IServiceScope _scope;

        public DotNetCoreServiceLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _scope = _serviceProvider.CreateScope();
        }

        public T Resolve<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public T ResolveAs<T>(Type type) where T : class
        {
            return (T) _serviceProvider.GetRequiredService(type);
        }

        public void ResetScope()
        {

        }
    }
}