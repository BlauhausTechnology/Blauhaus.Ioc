using System;

namespace Blauhaus.Ioc.IntegrationTests.TestObjects
{
    public class ParameterObject
    {
        public ParameterObject()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public override string ToString()
        {
            return "Paramater Object " + Id;
        }
    }
}