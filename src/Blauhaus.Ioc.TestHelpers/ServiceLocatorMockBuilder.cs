using System;
using System.Collections.Generic;
using Blauhaus.Common.Abstractions;
using Blauhaus.Ioc.Abstractions;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Ioc.TestHelpers
{
    public class ServiceLocatorMockBuilder : BaseMockBuilder<ServiceLocatorMockBuilder, IServiceLocator>
    {
        public ServiceLocatorMockBuilder Where_ResolveAndInitializeAsync_returns<T>(T value) where T : class, IAsyncInitializable<Guid>
        {
            Mock.Setup(x => x.ResolveAndInitializeAsync<T, Guid>(It.IsAny<Guid>()))
                .ReturnsAsync(value);
            return this;
        }
        public ServiceLocatorMockBuilder Where_ResolveAndInitializeAsync_returns<T>(T value, Guid id) where T : class, IAsyncInitializable<Guid>
        {
            Mock.Setup(x => x.ResolveAndInitializeAsync<T, Guid>(id))
                .ReturnsAsync(value);
            return this;
        }
        public ServiceLocatorMockBuilder Where_ResolveAndInitializeAsync_returns_sequence<T>(IEnumerable<T> values) where T : class, IAsyncInitializable<Guid>
        {
            var queue = new Queue<T>(values);
            Mock.Setup(x => x.ResolveAndInitializeAsync<T, Guid>(It.IsAny<Guid>())).ReturnsAsync(queue.Dequeue);
            return this;
        } 
        public ServiceLocatorMockBuilder Where_ResolveAndInitializeAsync_returns<T, TId>(T value) where T : class, IAsyncInitializable<TId>
        {
            Mock.Setup(x => x.ResolveAndInitializeAsync<T, TId>(It.IsAny<TId>()))
                .ReturnsAsync(value);
            return this;
        }
        public ServiceLocatorMockBuilder Where_ResolveAndInitializeAsync_returns<T, TId>(T value, TId id) where T : class, IAsyncInitializable<TId>
        {
            Mock.Setup(x => x.ResolveAndInitializeAsync<T, TId>(id))
                .ReturnsAsync(value);
            return this;
        }
        public ServiceLocatorMockBuilder Where_ResolveAndInitializeAsync_returns_sequence<T, TId>(IEnumerable<T> values) where T : class, IAsyncInitializable<TId>
        {
            var queue = new Queue<T>(values);
            Mock.Setup(x => x.ResolveAndInitializeAsync<T, TId>(It.IsAny<TId>())).ReturnsAsync(queue.Dequeue);
            return this;
        } 


        public ServiceLocatorMockBuilder Where_Resolve_returns<T>(T value) where T : class
        {
            Mock.Setup(x => x.Resolve<T>())
                .Returns(value);
            return this;
        }
        public ServiceLocatorMockBuilder Where_Resolve_returns_sequence<T>(IEnumerable<T> values) where T : class
        {
            var queue = new Queue<T>(values);
            Mock.Setup(x => x.Resolve<T>()).Returns(queue.Dequeue);
            return this;
        }
        public ServiceLocatorMockBuilder Where_Resolve_throws<T>(string exceptionMessage) where T : class
        {
            Mock.Setup(x => x.Resolve<T>())
                .Throws(new Exception(exceptionMessage));
            return this;
        }
        
        public ServiceLocatorMockBuilder Where_Resolve_returns(object value, Type? type = null)
        {
            if (type == null)
            {
                Mock.Setup(x => x.Resolve(It.IsAny<Type>())).Returns(value);
            }
            else
            {
                Mock.Setup(x => x.Resolve(type)).Returns(value);
            }
            return this;
        }
        public ServiceLocatorMockBuilder Where_Resolve_returns_sequence(IEnumerable<object> values)  
        {
            var queue = new Queue<object>(values);
            Mock.Setup(x => x.Resolve(It.IsAny<Type>())).Returns(queue.Dequeue);
            return this;
        }
        public ServiceLocatorMockBuilder Where_Resolve_throws(string exceptionMessage) 
        {
            Mock.Setup(x => x.Resolve(It.IsAny<Type>()))
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
        public ServiceLocatorMockBuilder Where_ResolveAs_returns_sequence<T>(IEnumerable<T> values) where T : class
        {
            var queue = new Queue<T>(values);
            Mock.Setup(x => x.ResolveAs<T>(It.IsAny<Type>())).Returns(queue.Dequeue);
            return this;
        }
        public ServiceLocatorMockBuilder Where_ResolveAs_throws<T>(string exceptionMessage) where T : class
        {
            Mock.Setup(x => x.ResolveAs<T>(It.IsAny<Type>()))
                .Throws(new Exception(exceptionMessage));
            return this;
        }

        
        public ServiceLocatorMockBuilder Where_ResolveAs_returns(IDisposable scope)
        {
            Mock.Setup(x => x.ResetScope()).Returns(scope);
            return this;
        }
    }
}