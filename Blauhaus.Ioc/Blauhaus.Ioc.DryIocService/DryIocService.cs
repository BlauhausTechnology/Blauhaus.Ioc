using System;
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
            try
            {
                _dryIocContainer.Register<T>(lifeTime == IocLifetime.Transient ? Reuse.Transient : Reuse.Singleton);
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
                _dryIocContainer.Register<T, TImplementation>(lifeTime == IocLifetime.Transient ? Reuse.Transient : Reuse.Singleton);
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
                return _dryIocContainer.Resolve<T>();
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
                instance = _dryIocContainer.Resolve<T>();
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
                instance = _dryIocContainer.Resolve<T>();
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

        public void Dispose()
        {
            _dryIocContainer?.Dispose();
        }
    }
}
