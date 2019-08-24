using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.DryIocServiceTests
{
    public class RegisterTypeTests
    {
        [SetUp]
        public void Setup()
        {
        }

       
        [Test]
        public void SHOULD_Resolve_object()
        {
            //Arrange
            var container = new DryIoc.Container();
            var sut = new DryIocService.DryIocService(container);

            //Act
            sut.RegisterType<ObjectA>();

            //Assert
            var result = sut.Resolve<ObjectA>();
            Assert.That(result, Is.InstanceOf<ObjectA>());
        }

        [Test]
        public void WHEN_IocLifetime_is_Transient_SHOULD_Resolve_new_instance_each_time()
        {
            //Arrange
            var container = new DryIoc.Container();
            var sut = new DryIocService.DryIocService(container);

            //Act
            sut.RegisterType<ObjectA>(IocLifetime.Transient);

            //Assert
            var result1 = sut.Resolve<ObjectA>();
            var result2 = sut.Resolve<ObjectA>();
            Assert.That(result1.Id, Is.Not.EqualTo(result2.Id));
            Assert.That(result1, Is.Not.EqualTo(result2));
        }
        
        [Test]
        public void WHEN_IocLifetime_is_Singleton_SHOULD_Resolve_same_instance_each_time()
        {
            //Arrange
            var container = new DryIoc.Container();
            var sut = new DryIocService.DryIocService(container);

            //Act
            sut.RegisterType<ObjectA>(IocLifetime.Singleton);

            //Assert
            var result1 = sut.Resolve<ObjectA>();
            var result2 = sut.Resolve<ObjectA>();
            Assert.That(result1.Id, Is.EqualTo(result2.Id));
            Assert.That(result1, Is.EqualTo(result2));
        }
    }
}