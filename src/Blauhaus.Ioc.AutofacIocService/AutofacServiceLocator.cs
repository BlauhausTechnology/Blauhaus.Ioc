using System;
using System.Threading.Tasks;
using Autofac;
using Blauhaus.Common.Abstractions;
using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.Ioc.AutofacIocService
{
    public class AutofacServiceLocator : IServiceLocator
    {
        private ILifetimeScope _scope;

        public void Initialize(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public T Resolve<T>() where T : class
        {
            return _scope.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _scope.Resolve(type);
        }

        public T ResolveAs<T>(Type type) where T : class
        {
            return (T)_scope.Resolve(type);
        }

        public Task<T> ResolveAndInitializeAsync<T, TId>(TId id) where T : class, IAsyncInitializable<TId>
        {
            throw new NotImplementedException();
        }

        public IDisposable ResetScope()
        {
            throw new NotImplementedException();
        }


    }
}