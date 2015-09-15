using System;

namespace AutoGetHashCode.Exceptions
{
    public class ClassNotPartialException : Exception
    {
        public ClassNotPartialException(string message)
            : base(message)
        {
        }
    }
}