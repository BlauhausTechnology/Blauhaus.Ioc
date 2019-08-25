using System;

namespace Blauhaus.Ioc.IntegrationTests.TestObjects
{
    public class BadObjectA : IObjectA
    {
        public BadObjectA()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
        public string StringParameter { get; private set; }
        public ParameterObject ObjectParameter { get; private set; }


        public void Initialize(string initializer)
        {
            throw new Exception("Failed to initialize by string");
        }


        public void Initialize(ParameterObject initializer)
        {
            throw new Exception("Failed to initialize by object");
        }

    }
}