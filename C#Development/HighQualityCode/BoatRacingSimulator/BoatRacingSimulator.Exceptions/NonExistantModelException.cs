namespace BoatRacingSimulator.Exceptions
{
    using System;

    public class NonExistantModelException : Exception
    {
        public NonExistantModelException(string message)
            : base(message)
        {
        }
    }
}