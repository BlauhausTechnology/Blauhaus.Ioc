using System;

namespace Blauhaus.Ioc.Abstractions
{
    public abstract class BaseIocService : IIocService
    {
         public void RegisterType<T>(IocLifetime lifeTime = IocLifetime.Transient)  where T : class
        {
            try
            {
                RegisterTypeWithContainer<T>(lifeTime);
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to register {typeof(T).Name} with the Ioc container", e);
            }
        }


        public void RegisterImplementation<TInterface, TImplementation>(IocLifetime lifeTime = IocLifetime.Transient) where TImplementation : class, TInterface where TInterface : class
        {
 
            try
            {
                RegisterImplementationWithContainer<TInterface, TImplementation>(lifeTime);
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to register {typeof(TImplementation).Name} as implementation of {typeof(TInterface).Name} with the Ioc container", e);
            }
        }

        public void RegisterInstance<T>(T instance) where T : class
        {
            try
            {
                RegisterInstanceWithContainer<T>(instance);
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to register instance of {typeof(T).Name} with the Ioc container", e);
            }
        }


        public T Resolve<T>() where T : class 
        {
            try
            {
                return ResolveFromContainer<T>();
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to resolve {typeof(T).Name} from the Ioc container", e);
            }
        }

        public object ResolveType(Type type)
        {
            try
            {
                return ResolveTypeFromContainer(type);
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to resolve {type.Name} from the Ioc container", e);
            }
        }

        public bool TryResolve<T>(out T instance) where T : class
        {
            try
            {
                instance = ResolveFromContainer<T>();
                return true;
            }
            catch (Exception)
            {
                instance = default;
                return false;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        protected abstract void RegisterTypeWithContainer<T>(IocLifetime lifeTime)  where T : class;
        protected abstract void RegisterImplementationWithContainer<TInterface, TImplementation>(IocLifetime lifeTime) where TImplementation : class, TInterface where TInterface : class;
        protected abstract void RegisterInstanceWithContainer<T>(T instance) where T : class;
        
        protected abstract object ResolveTypeFromContainer(Type type);
        protected abstract T ResolveFromContainer<T>() where T : class;

        protected abstract void Dispose(bool disposing);
    }
}