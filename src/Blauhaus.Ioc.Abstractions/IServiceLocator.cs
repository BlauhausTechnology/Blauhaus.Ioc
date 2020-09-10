using System;
using System.Threading.Tasks;

namespace Blauhaus.Ioc.Abstractions
{
    public interface IServiceLocator
    {
        T Resolve<T>() where T : class;
        T ResolveAs<T>(Type type) where T : class;

        IDisposable ResetScope(); 

    }
}