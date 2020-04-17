using System;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.ServiceProviderIocService
{
    public class ServiceProviderIocService : BaseIocService
    {
        private IServiceProvider _serviceProvider;

        public ServiceProviderIocService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void RegisterTypeWithContainer<T>(IocLifetime lifeTime)
        {
            throw new NotImplementedException();
        }

        protected override void RegisterImplementationWithContainer<TInterface, TImplementation>(IocLifetime lifeTime)
        {
            throw new NotImplementedException();
        }

        protected override void RegisterInstanceWithContainer<T>(T instance)
        {
            throw new NotImplementedException();
        }

        protected override object ResolveTypeFromContainer(Type type)
        {
            return _serviceProvider.GetRequiredService(type);
        }

        protected override T ResolveFromContainer<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        protected override void Dispose(bool disposing)
        {
            _serviceProvider = null;
        }
    }
}
