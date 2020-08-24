using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseResolveTypeTests : BaseIocServiceTest
    {
        [Test]
        public void SHOULD_resolve_object()
        {
            //Arrange
            Sut.RegisterType<ObjectA>();

            //Act
            var result = Sut.ResolveType(typeof(ObjectA));

            //Assert
            Assert.That(result, Is.InstanceOf<ObjectA>());
        }

        
    }
}