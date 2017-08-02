namespace _04.OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var songs = new List<Song>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .ToLower()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    var artistName = line[0];
                    var songName = line[1];

                    var timeTokens = line[2]
                        .Split(':')
                        .ToArray();


                    if (int.TryParse(timeTokens[0], out int minutes) && int.TryParse(timeTokens[1], out int seconds))
                    {

                        if (minutes * 60 + seconds > 0 || minutes * 60 + seconds < 14 * 60 + 59)
                        {
                            songs.Add(new Song(artistName, songName, minutes, seconds));
                            Console.WriteLine("Song added.");
                        }

                    }
                    else
                    {
                        throw new InvalidSongLengthException();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Songs added: {songs.Count}");

            var totalSeconds = songs
                .Select(s => s.Seconds)
                .Sum();

            var secondsToMinutes = totalSeconds / 60;
            var second = totalSeconds % 60;

            var totalMinutes = songs
                .Select(s => s.Minutes)
                .Sum() + secondsToMinutes;

            var minutesToHours = totalMinutes / 60;
            var minute = totalMinutes % 60;
            var hours = minutesToHours;

            Console.WriteLine($"Playlist length: {hours}h {minute}m {second}s");
        }
    }
}
