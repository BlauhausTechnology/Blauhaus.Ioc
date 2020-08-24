using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseRegisterImplementationTests : BaseIocServiceTest
    {
        
        [Test]
        public void SHOULD_Resolve_object()
        {
            //Act
            Sut.RegisterImplementation<IObjectA, ObjectA>();

            //Assert
            var result = Sut.Resolve<IObjectA>();
            Assert.That(result, Is.InstanceOf<ObjectA>());
        }

        [Test]
        public void WHEN_IocLifetime_is_Transient_SHOULD_Resolve_new_instance_each_time()
        {
            //Act
            Sut.RegisterImplementation<IObjectA, ObjectA>(IocLifetime.Transient);

            //Assert
            var result1 = Sut.Resolve<IObjectA>();
            var result2 = Sut.Resolve<IObjectA>();
            Assert.That(result1.Id, Is.Not.EqualTo(result2.Id));
            Assert.That(result1, Is.Not.EqualTo(result2));
        }
        
        [Test]
        public void WHEN_IocLifetime_is_Singleton_SHOULD_Resolve_same_instance_each_time()
        {
            //Act
            Sut.RegisterImplementation<IObjectA, ObjectA>(IocLifetime.Singleton);

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
            Sut.RegisterType<ObjectA>();
            Sut.Dispose();

            //Act and Assert
            var thrownException = Assert.Throws<IocContainerException>(() => Sut.RegisterImplementation<IObjectA, ObjectA>(IocLifetime.Singleton));
            Assert.That(thrownException.Message, Is.EqualTo("Failed to register ObjectA as implementation of IObjectA with the Ioc container"));
        }
    }
}