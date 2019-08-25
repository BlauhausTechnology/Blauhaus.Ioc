using System;

namespace Blauhaus.Ioc.Abstractions
{
    public abstract class BaseIocService : IIocService
    {
         public void RegisterType<T>(IocLifetime lifeTime = IocLifetime.Transient)
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


        public void RegisterImplementation<T, TImplementation>(IocLifetime lifeTime = IocLifetime.Transient) where TImplementation : T
        {
 
            try
            {
                RegisterImplementationWithContainer<T, TImplementation>(lifeTime);
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to register {typeof(TImplementation).Name} as implementation of {typeof(T).Name} with the Ioc container", e);
            }
        }
        
       
        public T Resolve<T>()
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
        

        public T ResolveAndInitialize<T, TParam>(TParam param) where T : IInitializable<TParam>
        {
            T instance;
            try
            {
                instance = ResolveFromContainer<T>();
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to resolve {typeof(T).Name} from the Ioc container", e);
            }

            try
            {
                instance.Initialize(param);
                return instance;
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to initialize {typeof(T).Name} using parameter {param}", e);
            }

        }

        public T ResolveAndInitializeById<T>(string param) where T : IInitializable<string>
        {
            T instance;
            try
            {
                instance = ResolveFromContainer<T>();
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to resolve {typeof(T).Name} from the Ioc container", e);
            }

            try
            {
                instance.Initialize(param);
                return instance;
            }
            catch (Exception e)
            {
                throw new IocContainerException($"Failed to initialize {typeof(T).Name} using parameter {param}", e);
            }
        }

        public bool TryResolve<T>(out T instance)
        {
            try
            {
                instance = ResolveFromContainer<T>();
                return true;
            }
            catch (Exception)
            {
                instance = default(T);
                return false;
            }

        }

        public bool TryResolveAndInitialize<T, TParam>(TParam param, out T instance) where T : IInitializable<TParam>
        {
            try
            {
                instance = ResolveFromContainer<T>();
                instance.Initialize(param);
                return true;
            }
            catch (Exception)
            {
                instance = default;
                return false;
            }

        }

        public bool TryResolveAndInitializeById<T>(string param, out T instance) where T : IInitializable<string>
        {
            try
            {
                instance = ResolveFromContainer<T>();
                instance.Initialize(param);
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

        
        protected abstract void RegisterTypeWithContainer<T>(IocLifetime lifeTime);
        protected abstract void RegisterImplementationWithContainer<T, TImplementation>(IocLifetime lifeTime) where TImplementation : T;
        protected abstract T ResolveFromContainer<T>();
        protected abstract void Dispose(bool disposing);
    }
}