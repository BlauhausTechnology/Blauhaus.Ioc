using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.Ioc.IntegrationTests.TestObjects
{
    public interface IObjectA : IInitializable<string>, IInitializable<ParameterObject>
    {
        string Id { get; }       
        string StringParameter { get; }
        ParameterObject ObjectParameter { get; }
    }
}