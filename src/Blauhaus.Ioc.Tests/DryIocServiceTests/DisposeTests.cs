﻿using Blauhaus.Ioc.Abstractions;
using Blauhaus.Ioc.IntegrationTests.Base;
using DryIoc;
using NUnit.Framework;

namespace Blauhaus.Ioc.IntegrationTests.DryIocServiceTests
{
    [TestFixture]
    public class DisposeTests : BaseDisposeTests
    {
            
        protected override IIocService ConstructSut()
        {
            return new DryIocService.DryIocService(new Container());
        }

    }
}