namespace _04.OnlineRadioDatabase.Exceptions
{
    public class InvalidArtistNameException : InvalidSongException
    {
        public override string Message => $"Artist name should be between {(int)LengthEnum.MinArtistNameLength} and {(int)LengthEnum.MaxArtistNameLength} symbols.";
    }
}