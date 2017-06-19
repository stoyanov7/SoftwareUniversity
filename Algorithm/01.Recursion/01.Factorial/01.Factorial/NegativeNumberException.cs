using System;
using System.Runtime.Serialization;

namespace _01.Factorial
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() : base() { }

        public NegativeNumberException(string message) : base(message) { }

        public NegativeNumberException(string message, Exception innerException) : base(message, innerException) { }

        public NegativeNumberException(SerializationInfo info, StreamingContext contex) : base(info, contex) { }
    }
}