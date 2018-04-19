namespace BoatRacingSimulator.Exceptions
{
    using System;

    public class DuplicateModelException : Exception
    {
        public DuplicateModelException(string message)
            : base(message)
        {
        }
    }
}
