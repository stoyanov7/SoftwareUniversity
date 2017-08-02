namespace _04.OnlineRadioDatabase.Exceptions
{
    using System;

    public class InvalidSongException : Exception
    {
        private string exceptionMessage = "Invalid song.";

        public virtual string ExceptionMessage
        {
            set => this.exceptionMessage = value;
        }

        public override string Message => exceptionMessage;
    }
}