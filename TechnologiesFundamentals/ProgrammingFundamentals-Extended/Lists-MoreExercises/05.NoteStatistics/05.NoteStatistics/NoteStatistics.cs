namespace _05.NoteStatistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NoteStatistics
    {
        public static void Main()
        {
            var notesValues = new Dictionary<string, double>
            {
                { "C", 261.63 },
                { "C#", 277.18 },
                { "D", 293.66 },
                { "D#", 311.13 },
                { "E", 329.63 },
                { "F", 349.23 },
                { "F#", 369.99 },
                { "G", 392.00 },
                { "G#", 415.30 },
                { "A", 440.00 },
                { "A#", 466.16 },
                { "B", 493.88 }
            };

            var values = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();

            var notes = new List<string>();
            var naturals = new List<string>();
            var sharps = new List<string>();

            for (var i = 0; i < values.Count; i++)
            {
                var note = notesValues
                    .Where(x => x.Value == values[i])
                    .Select(x => x.Key)
                    .First();

                if (note.Contains("#"))
                {
                    sharps.Add(string.Join(string.Empty, note));
                }
                else
                {
                    naturals.Add(string.Join(string.Empty, note));
                }

                notes.Add(string.Join(string.Empty, note));
            }

            Console.WriteLine($"Notes: {string.Join(" ", notes)}");
            Console.WriteLine($"Naturals: {string.Join(", ", naturals)}");
            Console.WriteLine($"Sharps: {string.Join(", ", sharps)}");

            var naturalSum = GetSum(notesValues, naturals);
            var sharpSum = GetSum(notesValues, sharps);

            var naturalSumResult = naturalSum > 0 ? $"Naturals sum: {naturalSum:F2}" : $"Naturals sum: 0";
            var sharpSumResult = sharpSum > 0 ? $"Sharps sum: {sharpSum:F2}" : $"Sharps sum: 0";

            Console.WriteLine(naturalSumResult);
            Console.WriteLine(sharpSumResult);
        }

        private static double GetSum(Dictionary<string, double> values, List<string> elements)
        {
            var sum = 0d;

            foreach (var element in elements)
            {
                sum += values[element];
            }

            return sum;
        }
    }
}