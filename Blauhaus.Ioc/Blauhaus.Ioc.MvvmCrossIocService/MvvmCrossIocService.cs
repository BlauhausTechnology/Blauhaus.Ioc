using Blauhaus.Ioc.Abstractions;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.IoC;

namespace Blauhaus.Ioc.MvvmCrossIocService
{
    public class MvvmCrossIocService : BaseIocService
    {
        private IMvxIoCProvider _iocContainer;

        public MvvmCrossIocService(IMvxIoCProvider iocContainer)
        {
            _iocContainer = iocContainer;
        }


        protected override void RegisterTypeWithContainer<T>(IocLifetime lifeTime)
        {
            if (lifeTime == IocLifetime.Transient)
            {
                _iocContainer.RegisterType<T>();
            }
            else
            {
                _iocContainer.LazyConstructAndRegisterSingleton<T, T>();
            }
        }

        protected override void RegisterImplementationWithContainer<TInterface, TImplementation>(IocLifetime lifeTime)
        {
            if (lifeTime == IocLifetime.Transient)
            {
                _iocContainer.RegisterType<TInterface, TImplementation>();
            }
            else
            {
                _iocContainer.LazyConstructAndRegisterSingleton<TInterface, TImplementation>();
            }
        }

        protected override T ResolveFromContainer<T>() 
        {
            return _iocContainer.Resolve<T>();
        }

        protected override void Dispose(bool disposing)
        {
            _iocContainer = null;
        }
    }
}