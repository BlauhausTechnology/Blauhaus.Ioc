using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseTryResolveAndInitializeTests : BaseIocServiceTest
    {
        [Test]
        public void IF_instance_is_resolved_SHOULD_return_true()
        {
            //Arrange
            Sut.RegisterImplementation<IObjectA, ObjectA>();
            var paramater = new ParameterObject();

            //Act
            var result = Sut.TryResolveAndInitialize<IObjectA, ParameterObject>(paramater, out var instance);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(instance, Is.InstanceOf<ObjectA>());
        }

        
        [Test]
        public void IF_instance_is_NOT_resolved_SHOULD_return_false()
        {
            //Arrange
            Sut.RegisterImplementation<IObjectA, ObjectA>();
            var paramater = new ParameterObject();
            Sut.Dispose();

            //Act
            var result = Sut.TryResolveAndInitialize<IObjectA, ParameterObject>(paramater, out var instance);

            //Assert
            Assert.That(result, Is.False);
            Assert.That(instance, Is.Null);
        }
    }
}