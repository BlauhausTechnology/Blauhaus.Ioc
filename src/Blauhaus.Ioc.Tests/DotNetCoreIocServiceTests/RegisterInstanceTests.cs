using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Ioc.IntegrationTests.DotNetCoreIocServiceTests
{
    public class RegisterInstanceTests : BaseRegisterInstanceTests
    {
        protected override IIocService ConstructSut()
        {
            return new DotNetCoreIocService.DotNetCoreIocService(new ServiceCollection());
        }
    }
}