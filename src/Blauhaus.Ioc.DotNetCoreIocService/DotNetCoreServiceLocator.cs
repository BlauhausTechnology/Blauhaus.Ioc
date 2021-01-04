using System;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.DotNetCoreIocService
{
    public class DotNetCoreServiceLocator : IServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;
        private IServiceScope? _scope;

        public DotNetCoreServiceLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>() where T : class
        {
            return _scope == null 
                ? _serviceProvider.GetRequiredService<T>() 
                : _scope.ServiceProvider.GetRequiredService<T>();

        }

        public object Resolve(Type type)
        {
            return _scope == null 
                ? _serviceProvider.GetRequiredService(type) 
                : _scope.ServiceProvider.GetRequiredService(type);
        }

        public T ResolveAs<T>(Type type) where T : class
        {
            return (T) (_scope == null 
                ? _serviceProvider.GetRequiredService(type) 
                : _scope.ServiceProvider.GetRequiredService(type));
        }

        public IDisposable ResetScope()
        {
            _scope?.Dispose();
            _scope = _serviceProvider.CreateScope();
            return _scope;
        }
         
    }
}