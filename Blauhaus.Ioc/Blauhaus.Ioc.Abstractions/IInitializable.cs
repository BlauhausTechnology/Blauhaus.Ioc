namespace Blauhaus.Ioc.Abstractions
{
    public interface IInitializable<in T>
    {
        void Initialize(T initializer);
    }
}