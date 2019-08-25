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
    }
}