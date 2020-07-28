using System;
using Blauhaus.Ioc.Abstractions;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Ioc.TestHelpers
{
    public class ServiceLocatorMockBuilder : BaseMockBuilder<ServiceLocatorMockBuilder, IServiceLocator>
    {
        public ServiceLocatorMockBuilder Where_Resolve_returns<T>(T value) where T : class
        {
            Mock.Setup(x => x.Resolve<T>())
                .Returns(value);
            return this;
        }
        public ServiceLocatorMockBuilder Where_Resolve_throws<T>(string exceptionMessage) where T : class
        {
            Mock.Setup(x => x.Resolve<T>())
                .Throws(new Exception(exceptionMessage));
            return this;
        }


        public ServiceLocatorMockBuilder Where_ResolveAs_returns<T>(T value) where T : class
        {
            Mock.Setup(x => x.ResolveAs<T>(It.IsAny<Type>()))
                .Returns(value);
            return this;
        }
        public ServiceLocatorMockBuilder Where_ResolveAs_returns<T>(T value, Type type) where T : class
        {
            Mock.Setup(x => x.ResolveAs<T>(type))
                .Returns(value);
            return this;
        }
        public ServiceLocatorMockBuilder Where_ResolveAs_throws<T>(string exceptionMessage) where T : class
        {
            Mock.Setup(x => x.ResolveAs<T>(It.IsAny<Type>()))
                .Throws(new Exception(exceptionMessage));
            return this;
        }
    }
}