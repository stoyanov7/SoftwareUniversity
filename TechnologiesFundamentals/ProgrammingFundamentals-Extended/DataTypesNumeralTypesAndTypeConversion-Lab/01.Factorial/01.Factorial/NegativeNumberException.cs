using System;
using System.Runtime.Serialization;

namespace _01.Factorial
{
    [Serializable]
    internal class NegativeNumberException : Exception
    {
        public NegativeNumberException()
        {
            Console.WriteLine("Cannot use negative number!");
        }

        public NegativeNumberException(string message) : base(message)
        {
        }

        public NegativeNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}