using System;

namespace Blauhaus.Ioc.IntegrationTests.TestObjects
{
    public class ObjectA : IObjectA
    {
        public ObjectA()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }



    }
}