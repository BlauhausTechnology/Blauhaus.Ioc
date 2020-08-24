using System;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.DotNetCoreIocService
{
    public class DotNetCoreIocService : BaseIocService
    {
        private IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProviderInstance;
        private IServiceProvider ServiceProvider => _serviceProviderInstance ??= _serviceCollection.BuildServiceProvider();

        public DotNetCoreIocService(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
            _serviceCollection.AddSingleton<IIocService>(this);
            _serviceProviderInstance = serviceCollection.BuildServiceProvider();
        }

        protected override void RegisterTypeWithContainer<T>(IocLifetime lifeTime)
        {
            if (lifeTime == IocLifetime.Singleton)
            {
                _serviceCollection.AddSingleton<T>();
                _serviceProviderInstance = _serviceCollection.BuildServiceProvider();
            }
            else
            {
                _serviceCollection.AddTransient<T>();
                _serviceProviderInstance = _serviceCollection.BuildServiceProvider();
            }
        }

        protected override void RegisterImplementationWithContainer<TInterface, TImplementation>(IocLifetime lifeTime)
        {
            if (lifeTime == IocLifetime.Singleton)
            {
                _serviceCollection.AddSingleton<TInterface, TImplementation>();
                _serviceProviderInstance = _serviceCollection.BuildServiceProvider();
            }
            else
            {
                _serviceCollection.AddTransient<TInterface, TImplementation>();
                _serviceProviderInstance = _serviceCollection.BuildServiceProvider();
            }
        }

        protected override void RegisterInstanceWithContainer<T>(T instance)
        {
            _serviceCollection.AddSingleton<T>(instance);
            _serviceProviderInstance = _serviceCollection.BuildServiceProvider();
        }

        protected override T ResolveFromContainer<T>()
        {
            return _serviceProviderInstance.GetService<T>();
        }
        
        protected override object ResolveTypeFromContainer(Type type)
        {
            return _serviceProviderInstance.GetService(type);
        }


        protected override void Dispose(bool disposing)
        {
            _serviceProviderInstance = null;
            _serviceCollection?.Clear();
            _serviceCollection = null;
        }
    }
}