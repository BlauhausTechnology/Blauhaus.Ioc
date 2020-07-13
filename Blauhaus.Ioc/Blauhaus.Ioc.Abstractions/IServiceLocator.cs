namespace Blauhaus.Ioc.Abstractions
{
    public interface IServiceLocator
    {
        T Resolve<T>() where T : class;
    }
}