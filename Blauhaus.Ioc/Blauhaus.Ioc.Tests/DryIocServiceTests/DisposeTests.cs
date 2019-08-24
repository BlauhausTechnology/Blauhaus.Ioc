using System;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using DryIoc;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.DryIocServiceTests
{
    [TestFixture]
    public class DisposeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [Test]
        public void SHOULD_Dispose_container()
        {
            //Arrange
            var container = new DryIoc.Container();
            var sut = new DryIocService.DryIocService(container);
            sut.RegisterType<ObjectA>();

            //Act and Assert
            sut.Dispose();
            Assert.Throws<ContainerException>(() => sut.Resolve<ObjectA>());

        }

    }
}