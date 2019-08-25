using System;

namespace Blauhaus.Ioc.Abstractions
{
    public interface IIocService : IDisposable
    {
        void RegisterType<T>(IocLifetime lifeTime = IocLifetime.Transient) where T : class;
        void RegisterImplementation<TInterface, TImplementation>(IocLifetime lifeTime = IocLifetime.Transient) where TImplementation : class, TInterface where TInterface : class;

        T Resolve<T>() where T : class;
        T ResolveAndInitialize<T, TParam>(TParam param) where T : class, IInitializable<TParam>;
        T ResolveAndInitializeById<T>(string param) where T : class, IInitializable<string>;

        bool TryResolve<T>(out T instance) where T : class;
        bool TryResolveAndInitialize<T, TParam>(TParam param, out T instance) where T : class, IInitializable<TParam>;
        bool TryResolveAndInitializeById<T>(string param, out T instance) where T : class, IInitializable<string>;
    }
}