using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.Base;
using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.DryIocServiceTests
{
    [TestFixture]
    public class ResolveTypeTests : BaseResolveTypeTests
    {
        
        protected override IIocService ConstructSut()
        {
            return new DryIocService.DryIocService(new Container());
        }

    }
}