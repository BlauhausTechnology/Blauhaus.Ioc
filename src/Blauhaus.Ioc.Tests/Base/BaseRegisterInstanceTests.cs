using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseRegisterInstanceTests : BaseIocServiceTest
    {
        
        [Test]
        public void WHEN_Registered_as_type_SHOULD_Register_object()
        {
            //Arrange
            var instance = new ObjectA();

            //Act
            Sut.RegisterInstance(instance);

            //Assert
            var result = Sut.Resolve<ObjectA>();
            Assert.That(result.Id, Is.EqualTo(instance.Id));
        }

        [Test]
        public void WHEN_Registered_as_interface_SHOULD_Register_object()
        {
            //Arrange
            var instance = new ObjectA();

            //Act
            Sut.RegisterInstance<IObjectA>(instance);

            //Assert
            var result = Sut.Resolve<IObjectA>();
            Assert.That(result.Id, Is.EqualTo(instance.Id));
        }

        [Test]
        public void SHOULD_Resolve_same_instance_each_time()
        {
            //Arrange
            var instance = new ObjectA();

            //Act
            Sut.RegisterInstance<IObjectA>(instance);

            //Assert
            var result1 = Sut.Resolve<IObjectA>();
            var result2 = Sut.Resolve<IObjectA>();
            Assert.That(result1.Id, Is.EqualTo(result2.Id));
            Assert.That(result1, Is.EqualTo(result2));
        }
        
        [Test]
        public void WHEN_fails_SHOULD_throw_exception()
        {
            //Arrange
            Sut.RegisterInstance<IObjectA>(new ObjectA());
            Sut.Dispose();

            //Act and Assert
            var thrownException = Assert.Throws<IocContainerException>(() => Sut.RegisterInstance<IObjectA>(new ObjectA()));
            Assert.That(thrownException.Message, Is.EqualTo("Failed to register instance of IObjectA with the Ioc container"));
        }
    }
}