using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.Base;
using DryIoc;
using MvvmCross.IoC;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.MvvmCrossIocServiceTests
{
    [TestFixture]
    public class RegisterImplementationTests : BaseRegisterImplementationTests
    {
       
        protected override IIocService ConstructSut()
        {
            return new MvvmCrossIocService.MvvmCrossIocService(MvxIoCProvider.Initialize());
        }
  
    }
}