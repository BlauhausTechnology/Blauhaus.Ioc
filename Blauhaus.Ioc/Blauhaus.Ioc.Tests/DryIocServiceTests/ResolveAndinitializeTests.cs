using Blauhaus.Ioc.IntegrationTests.TestObjects;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.DryIocServiceTests
{
    [TestFixture]
    public class ResolveAndinitializeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [Test]
        public void SHOULD_Initialize_with_parameter_type()
        {
            //Arrange
            var container = new DryIoc.Container();
            var sut = new DryIocService.DryIocService(container);
            sut.RegisterImplementation<IObjectA, ObjectA>();
            var paramater = new ParameterObject();

            //Act
            var result = sut.ResolveAndInitialize<IObjectA, ParameterObject>(paramater);

            //Assert
            Assert.That(result.ObjectParameter.Id, Is.EqualTo(paramater.Id));
        }

    }
}