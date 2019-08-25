using System;

namespace Blauhaus.Ioc.Abstractions
{
    public class IocContainerException : Exception
    {
        public IocContainerException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}