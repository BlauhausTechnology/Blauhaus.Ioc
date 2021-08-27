using System;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Ioc.Abstractions
{
    public interface IServiceLocator
    {
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        T ResolveAs<T>(Type type) where T : class;

        Task<T> ResolveAndInitializeAsync<T, TId>(TId id) where T : class, IAsyncInitializable<TId>;

        IDisposable ResetScope(); 

    }
}