using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TrackDownloader
{
    public class TrackDownloader
    {
        public static void Main(string[] args)
        {
            var blacklistedWord = Console.ReadLine()
                .Split(' ')
                .ToList();

            var filenames = Console.ReadLine();
            var result = new List<string>();

            while (!filenames.Equals("end"))
            {
                var contains = false;

                foreach (var filename in blacklistedWord)
                {
                    if (filenames.Contains(filename))
                    {
                        contains = true;
                    }
                }

                if (!contains)
                {
                    result.Add(filenames);
                }

                filenames = Console.ReadLine();
            }

            result = result.OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
