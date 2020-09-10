using System;
using Autofac;
using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.Ioc.AutofacIocService
{
    public class AutofacServiceLocator : IServiceLocator
    {
        private IContainer _container;
        private ILifetimeScope _scope;

        public void Initialize(IContainer container)
        {
            _container = container;
            ResetScope();
        }

        public T Resolve<T>() where T : class
        {
            return _scope.Resolve<T>();
        }

        public T ResolveAs<T>(Type type) where T : class
        {
            return (T)_scope.Resolve(type);
        }

        public IDisposable ResetScope()
        {
            _scope?.Dispose();
            _scope = _container.BeginLifetimeScope();
            return _scope;
        }

    }
}