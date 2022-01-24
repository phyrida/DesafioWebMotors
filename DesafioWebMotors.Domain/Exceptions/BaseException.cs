using System;
using System.Collections.Generic;

namespace DesafioWebMotors.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public int StatusCodeException { get; }

        public BaseException(string message) : base(message)
        {
        }

        public BaseException(string message, int statusCodeException) : base(message)
        {
            StatusCodeException = statusCodeException;
        }
    }
}
