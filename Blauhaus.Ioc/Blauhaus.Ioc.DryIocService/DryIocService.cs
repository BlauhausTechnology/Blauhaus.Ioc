using System;
using System.ComponentModel;
using Blauhaus.Ioc.Abstractions;
using DryIoc;
using IContainer = DryIoc.IContainer;

namespace Blauhaus.Ioc.DryIocService
{
    public class DryIocService : IIocService
    {
        private readonly IContainer _dryIocContainer;

        public DryIocService(IContainer dryIocContainer)
        {
            _dryIocContainer = dryIocContainer; 
        }
        
        public void RegisterType<T>(IocLifetime lifeTime = IocLifetime.Transient)
        {
            _dryIocContainer.Register<T>(lifeTime == IocLifetime.Transient ? Reuse.Transient : Reuse.Singleton);
        }

        public void RegisterImplementation<T, TImplementation>(IocLifetime lifeTime = IocLifetime.Transient) where TImplementation : T
        {
            _dryIocContainer.Register<T, TImplementation>(lifeTime == IocLifetime.Transient ? Reuse.Transient : Reuse.Singleton);
        }
        
       
        public T Resolve<T>()
        {
            return _dryIocContainer.Resolve<T>();
        }

        public T ResolveAndInitialize<T, TParam>(TParam param) where T : IInitializable<TParam>
        {
            var instance = _dryIocContainer.Resolve<T>();
            instance.Initialize(param);
            return instance;
        }

        public T ResolveAndInitializeById<T>(string param) where T : IInitializable<string>
        {
            var instance = _dryIocContainer.Resolve<T>();
            instance.Initialize(param);
            return instance;
        }

        public void Dispose()
        {
            _dryIocContainer?.Dispose();
        }
    }
}
