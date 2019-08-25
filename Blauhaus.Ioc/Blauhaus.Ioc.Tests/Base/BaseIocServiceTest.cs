using Blauhaus.Ioc.Abstractions;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.Base
{
    public abstract class BaseIocServiceTest
    {

        protected IIocService Sut; 

        [SetUp]
        public void Setup()
        {
            Sut = ConstructSut();
        }

        protected abstract IIocService ConstructSut();

        [TearDown]
        public void TearDown()
        {
            Sut.Dispose();
            Sut = null;
        }

    }
}