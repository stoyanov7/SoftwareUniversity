namespace BoatRacingSimulator.Exceptions
{
    using System;

    public class NotSetRaceException : Exception
    {
        public NotSetRaceException(string message)
            : base(message)
        {
        }
    }
}