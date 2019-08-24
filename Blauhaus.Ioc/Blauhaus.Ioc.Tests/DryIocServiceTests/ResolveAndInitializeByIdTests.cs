using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.DryIocServiceTests
{
    [TestFixture]
    public class ResolveAndInitializeByIdTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SHOULD_Initialize_with_string_parameter()
        {
            //Arrange
            var container = new DryIoc.Container();
            var sut = new DryIocService.DryIocService(container);
            sut.RegisterImplementation<IObjectA, ObjectA>();

            //Act
            var result = sut.ResolveAndInitializeById<IObjectA>("stringParam");

            //Assert
            Assert.That(result.StringParameter, Is.EqualTo("stringParam"));
        }
    }
}