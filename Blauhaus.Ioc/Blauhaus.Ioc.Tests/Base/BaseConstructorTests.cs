using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using DryIoc;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseConstructorTests : BaseIocServiceTest
    {
        [Test]
        public void SHOULD_register_self()
        {
            
            //Act and Assert
            var iocService = Sut.Resolve<IIocService>();
            Assert.That(iocService, Is.EqualTo(Sut));
        }

    }
}