﻿using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.Base;
using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.DotNetCoreIocServiceTests
{
    [TestFixture]
    public class ResolveAndInitializeByIdTests: BaseResolveAndInitializeByIdTests
    {
        protected override IIocService ConstructSut()
        {
            return new DotNetCoreIocService.DotNetCoreIocService(new ServiceCollection());
        }

    }
}