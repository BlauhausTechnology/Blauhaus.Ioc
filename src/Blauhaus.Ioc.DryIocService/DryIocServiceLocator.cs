using System;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.Ioc.Abstractions;
using DryIoc;

namespace Blauhaus.Ioc.DryIocService
{
    public class DryIocServiceLocator : IServiceLocator
    {
        private readonly IContainer _container;

        public DryIocServiceLocator(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public T ResolveAs<T>(Type type) where T : class
        {
            return (T) _container.Resolve(type);
        }

        public async Task<T> ResolveAndInitializeAsync<T, TId>(TId id) where T : class, IAsyncInitializable<TId>
        {
            var t = Resolve<T>();
            await t.InitializeAsync(id);
            return t;
        }
        
        public IDisposable ResetScope()
        {
            throw new NotImplementedException("Have not had a need for this yet");
        }
    }
}