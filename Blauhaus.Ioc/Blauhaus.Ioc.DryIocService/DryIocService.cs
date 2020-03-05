using System;
using Blauhaus.Ioc.Abstractions;
using DryIoc;
using IContainer = DryIoc.IContainer;

namespace Blauhaus.Ioc.DryIocService
{
    public class DryIocService : BaseIocService
    {
        private readonly IContainer _dryIocContainer;

        public DryIocService(IContainer dryIocContainer)
        {
            dryIocContainer.With(rules => rules.WithTrackingDisposableTransients());
            _dryIocContainer = dryIocContainer; 
            _dryIocContainer.UseInstance<IIocService>(this);
        }
        

        protected override void RegisterTypeWithContainer<T>(IocLifetime lifeTime)
        {
            _dryIocContainer.Register<T>(lifeTime == IocLifetime.Transient ? Reuse.Transient : Reuse.Singleton);
        }

        protected override void RegisterImplementationWithContainer<T, TImplementation>(IocLifetime lifeTime)
        {
            _dryIocContainer.Register<T, TImplementation>(lifeTime == IocLifetime.Transient ? Reuse.Transient : Reuse.Singleton);
        }

        protected override void RegisterInstanceWithContainer<T>(T instance)
        {
            _dryIocContainer.RegisterInstance(instance);
        }

        protected override T ResolveFromContainer<T>()
        {
            return _dryIocContainer.Resolve<T>();
        }

        protected override object ResolveTypeFromContainer(Type type)
        {
            return _dryIocContainer.Resolve(type);
        }

        protected override void Dispose(bool disposing)
        {
            _dryIocContainer?.Dispose();
        }
    }
}
