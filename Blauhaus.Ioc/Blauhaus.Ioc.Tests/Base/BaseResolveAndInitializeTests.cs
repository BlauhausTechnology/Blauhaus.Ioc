using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseResolveAndInitializeTests : BaseIocServiceTest
    {
        [Test]
        public void SHOULD_Initialize_with_parameter_type()
        {
            //Arrange
            Sut.RegisterImplementation<IObjectA, ObjectA>();
            var paramater = new ParameterObject();

            //Act
            var result = Sut.ResolveAndInitialize<IObjectA, ParameterObject>(paramater);

            //Assert
            Assert.That(result.ObjectParameter.Id, Is.EqualTo(paramater.Id));
        }

        [Test]
        public void WHEN_resolve_fails_SHOULD_throw_exception()
        {
            //Arrange
            Sut.RegisterImplementation<IObjectA, ObjectA>();
            Sut.Dispose();
            var paramater = new ParameterObject();

            //Act and Assert
            var thrownException = Assert.Throws<IocContainerException>(() => Sut.ResolveAndInitialize<IObjectA, ParameterObject>(paramater));
            Assert.That(thrownException.Message, Is.EqualTo("Failed to resolve IObjectA from the Ioc container"));
        }

        [Test]
        public void WHEN_resolve_succeeds_but_initialize_fails_SHOULD_throw_exception()
        {
            //Arrange
            Sut.RegisterImplementation<IObjectA, BadObjectA>();
            var paramater = new ParameterObject();

            //Act and Assert
            var thrownException = Assert.Throws<IocContainerException>(() => Sut.ResolveAndInitialize<IObjectA, ParameterObject>(paramater));
            Assert.That(thrownException.Message, Is.EqualTo($"Failed to initialize IObjectA using parameter {paramater}"));
            Assert.That(thrownException.InnerException.Message, Is.EqualTo("Failed to initialize by object"));
        }
    }
}