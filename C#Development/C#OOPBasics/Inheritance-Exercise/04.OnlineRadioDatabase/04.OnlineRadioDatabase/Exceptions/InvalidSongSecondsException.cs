namespace _04.OnlineRadioDatabase.Exceptions
{ 
    public class InvalidSongSecondsException : InvalidSongException
    {
        public override string Message => $"Song seconds should be between {(int)LengthEnum.MinMinutes} and {(int)LengthEnum.MaxMinutes}.";
    }
}