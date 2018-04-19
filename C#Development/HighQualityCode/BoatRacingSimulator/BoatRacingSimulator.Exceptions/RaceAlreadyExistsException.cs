namespace BoatRacingSimulator.Exceptions
{
    using System;

    public class RaceAlreadyExistsException : Exception
    {
        public RaceAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}