using System;
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

        public T ResolveAs<T>(Type type) where T : class
        {
            return (T) _container.Resolve(type);
        }
    }
}