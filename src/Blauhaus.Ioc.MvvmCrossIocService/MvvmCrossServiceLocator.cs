using System;
using Blauhaus.Common.Abstractions;
using System.Threading.Tasks;
using Blauhaus.Ioc.Abstractions;
using MvvmCross; 

namespace Blauhaus.Ioc.MvvmCrossIocService
{
    public class MvvmCrossServiceLocator : IServiceLocator
    {
        public T Resolve<T>() where T : class
        {
            return Mvx.IoCProvider.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return Mvx.IoCProvider.Resolve(type);
        }

        public T ResolveAs<T>(Type type) where T : class
        {
            return (T) Mvx.IoCProvider.Resolve(type);
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