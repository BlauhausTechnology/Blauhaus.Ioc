using System;
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

        public T ResolveAs<T>(Type type) where T : class
        {
            return (T) Mvx.IoCProvider.Resolve(type);
        }
        public IDisposable ResetScope()
        {
            throw new NotImplementedException("Have not had a need for this yet");
        }
    }
}