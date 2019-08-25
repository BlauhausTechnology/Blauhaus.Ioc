using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseResolveAndInitializeByIdTests : BaseIocServiceTest
    {
        [Test]
        public void SHOULD_Initialize_with_string_parameter()
        {
            //Arrange
            Sut.RegisterImplementation<IObjectA, ObjectA>();

            //Act
            var result = Sut.ResolveAndInitializeById<IObjectA>("stringParam");

            //Assert
            Assert.That(result.StringParameter, Is.EqualTo("stringParam"));
        }

        
        [Test]
        public void WHEN_resolve_fails_SHOULD_throw_exception()
        {
            //Arrange
            Sut.RegisterImplementation<IObjectA, ObjectA>();
            Sut.Dispose();

            //Act and Assert
            var thrownException = Assert.Throws<IocContainerException>(() => Sut.ResolveAndInitializeById<IObjectA>("stringParam"));
            Assert.That(thrownException.Message, Is.EqualTo("Failed to resolve IObjectA from the Ioc container"));
        }

        [Test]
        public void WHEN_resolve_succeeds_but_initialize_fails_SHOULD_throw_exception()
        {
            //Arrange
            Sut.RegisterImplementation<IObjectA, BadObjectA>();

            //Act and Assert
            var thrownException = Assert.Throws<IocContainerException>(() => Sut.ResolveAndInitializeById<IObjectA>("stringParam"));
            Assert.That(thrownException.Message, Is.EqualTo("Failed to initialize IObjectA using parameter stringParam"));
            Assert.That(thrownException.InnerException.Message, Is.EqualTo("Failed to initialize by string"));
        }
    }
}