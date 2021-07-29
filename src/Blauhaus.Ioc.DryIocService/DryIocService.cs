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
            _dryIocContainer.UseInstance<IIocService>(this, IfAlreadyRegistered.Replace);
        }
        

        protected override void RegisterTypeWithContainer<T>(IocLifetime lifeTime)
        {
            if(lifeTime == IocLifetime.Transient)
            {
                _dryIocContainer.Register<T>(Reuse.Transient, Made.Default, Setup.With(allowDisposableTransient: true));
            }
            else
            {
                _dryIocContainer.Register<T>(Reuse.Singleton);
            }
        }

        protected override void RegisterImplementationWithContainer<T, TImplementation>(IocLifetime lifeTime)
        {
            if (lifeTime == IocLifetime.Transient)
            {
                _dryIocContainer.Register<T, TImplementation>(Reuse.Transient, Made.Default, Setup.With(allowDisposableTransient: true));
            }
            else
            {
                _dryIocContainer.Register<T, TImplementation>(Reuse.Singleton);
            }
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
