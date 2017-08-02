namespace _04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongMinutesException : InvalidSongException
    {
        public override string Message => $"Song minutes should be between {(int)LengthEnum.MinMinutes} and {(int)LengthEnum.MaxMinutes}.";
    }
}