using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseRegisterTypeTests : BaseIocServiceTest
    {
        [Test]
        public void SHOULD_Resolve_object()
        {
            //Act
            Sut.RegisterType<ObjectA>();

            //Assert
            var result = Sut.Resolve<ObjectA>();
            Assert.That(result, Is.InstanceOf<ObjectA>());
        }

        [Test]
        public void WHEN_IocLifetime_is_Transient_SHOULD_Resolve_new_instance_each_time()
        {
            //Act
            Sut.RegisterType<ObjectA>(IocLifetime.Transient);

            //Assert
            var result1 = Sut.Resolve<ObjectA>();
            var result2 = Sut.Resolve<ObjectA>();
            Assert.That(result1.Id, Is.Not.EqualTo(result2.Id));
            Assert.That(result1, Is.Not.EqualTo(result2));
        }
        
        [Test]
        public void WHEN_IocLifetime_is_Singleton_SHOULD_Resolve_same_instance_each_time()
        {
            //Act
            Sut.RegisterType<ObjectA>(IocLifetime.Singleton);

            //Assert
            var result1 = Sut.Resolve<ObjectA>();
            var result2 = Sut.Resolve<ObjectA>();
            Assert.That(result1.Id, Is.EqualTo(result2.Id));
            Assert.That(result1, Is.EqualTo(result2));
        }
    }
}