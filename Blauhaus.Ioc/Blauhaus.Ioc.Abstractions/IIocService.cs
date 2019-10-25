using System;

namespace Blauhaus.Ioc.Abstractions
{
    public interface IIocService : IDisposable
    {
        void RegisterType<T>(IocLifetime lifeTime = IocLifetime.Transient) where T : class;
        void RegisterImplementation<TInterface, TImplementation>(IocLifetime lifeTime = IocLifetime.Transient) where TImplementation : class, TInterface where TInterface : class;
        void RegisterInstance<T>(T instance) where T : class;

        T Resolve<T>() where T : class;
        object ResolveType(Type type);
        bool TryResolve<T>(out T instance) where T : class;
    }
}