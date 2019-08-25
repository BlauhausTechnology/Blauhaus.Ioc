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
    }
}