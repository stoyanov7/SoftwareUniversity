namespace BoatRacingSimulator.Exceptions
{
    using System;

    public class InsufficientContestantsException : Exception
    {
        public InsufficientContestantsException(string message) 
            : base(message)
        {
        }
    }
}