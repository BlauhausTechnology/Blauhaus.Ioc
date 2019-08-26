using System;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.DotNetCoreIocService
{
    public class DotNetCoreIocService : BaseIocService
    {
        private IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;

        public DotNetCoreIocService(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
            _serviceCollection.AddSingleton<IIocService>(this);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void RegisterTypeWithContainer<T>(IocLifetime lifeTime)
        {
            if (lifeTime == IocLifetime.Singleton)
            {
                _serviceCollection.AddSingleton<T>();
                _serviceProvider = _serviceCollection.BuildServiceProvider();
            }
            else
            {
                _serviceCollection.AddTransient<T>();
                _serviceProvider = _serviceCollection.BuildServiceProvider();
            }
        }

        protected override void RegisterImplementationWithContainer<TInterface, TImplementation>(IocLifetime lifeTime)
        {
            if (lifeTime == IocLifetime.Singleton)
            {
                _serviceCollection.AddSingleton<TInterface, TImplementation>();
                _serviceProvider = _serviceCollection.BuildServiceProvider();
            }
            else
            {
                _serviceCollection.AddTransient<TInterface, TImplementation>();
                _serviceProvider = _serviceCollection.BuildServiceProvider();
            }
        }

        protected override T ResolveFromContainer<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        protected override void Dispose(bool disposing)
        {
            _serviceProvider = null;
            _serviceCollection?.Clear();
            _serviceCollection = null;
        }
    }
}