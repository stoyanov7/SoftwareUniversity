namespace _04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongNameException : InvalidSongException
    {
        public override string Message => $"Song name should be between {(int)LengthEnum.MinSongLength} and {(int)LengthEnum.MaxSongLength} symbols.";
    }
}