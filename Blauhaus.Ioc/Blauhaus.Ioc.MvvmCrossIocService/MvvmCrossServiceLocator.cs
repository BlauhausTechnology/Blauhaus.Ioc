using Blauhaus.Ioc.Abstractions;
using MvvmCross;

namespace Blauhaus.Ioc.MvvmCrossIocService
{
    public class MvvmCrossServiceLocator : IServiceLocator
    {
        public T Resolve<T>() where T : class
        {
            return Mvx.Resolve<T>();
        }
    }
}