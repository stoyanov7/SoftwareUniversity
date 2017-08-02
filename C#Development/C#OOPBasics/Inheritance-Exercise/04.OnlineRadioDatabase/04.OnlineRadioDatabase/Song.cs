﻿namespace _04.OnlineRadioDatabase
{
    using Exceptions;

    public class Song
    {
        private string artistName;
        private string songName;
        private int minutes;
        private int seconds;

        public Song(string artistName, string songName, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string ArtistName
        {
            get => this.artistName;

            private set
            {
                if (value.Length < (int)LengthEnum.MinArtistNameLength || value.Length > (int)LengthEnum.MaxArtistNameLength)
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get => this.songName;

            private set
            {
                if (value.Length < (int) LengthEnum.MinSongLength || value.Length > (int) LengthEnum.MaxSongLength)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

        public int Minutes
        {
            get => this.minutes;

            private set
            {
                if (value < (int)LengthEnum.MinMinutes || value > (int)LengthEnum.MaxMinutes)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public int Seconds
        {
            get => this.seconds;

            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
    }
}