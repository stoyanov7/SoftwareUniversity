using System;
using System.Runtime.Serialization;

namespace _04.OnlineRadioDatabase
{
    using Exceptions;
    [Serializable]
    public class InvalidSongLengthException : InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }
}