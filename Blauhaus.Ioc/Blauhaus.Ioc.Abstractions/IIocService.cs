using System;

namespace Blauhaus.Ioc.Abstractions
{
    public interface IIocService : IDisposable
    {
        void RegisterType<T>(IocLifetime lifeTime = IocLifetime.Transient);
        void RegisterImplementation<T, TImplementation>(IocLifetime lifeTime = IocLifetime.Transient) where TImplementation : T;

        T Resolve<T>();
        T ResolveAndInitialize<T, TParam>(TParam param) where T : IInitializable<TParam>;
        T ResolveAndInitializeById<T>(string param) where T : IInitializable<string>;

        bool TryResolve<T>(out T instance);
        bool TryResolveAndInitialize<T, TParam>(TParam param, out T instance) where T : IInitializable<TParam>;
        bool TryResolveAndInitializeById<T>(string param, out T instance) where T : IInitializable<string>;
    }
}