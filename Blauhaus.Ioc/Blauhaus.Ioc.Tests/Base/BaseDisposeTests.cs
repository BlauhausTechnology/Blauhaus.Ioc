using Blauhaus.Ioc.IntegrationTests.TestObjects;
using DryIoc;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseDisposeTests : BaseIocServiceTest
    {
        [Test]
        public void SHOULD_Dispose_container()
        {
            //Arrange
            Sut.RegisterType<ObjectA>();

            //Act and Assert
            Sut.Dispose();
            Assert.Throws<ContainerException>(() => Sut.Resolve<ObjectA>());
        }

    }
}