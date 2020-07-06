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

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}