namespace _02.UpperStrings
{
    using System;
    using System.Linq;

    public class UpperStrings
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(' ')
                .Select(w => w.ToUpper())
                .ToList();

            words.ForEach(w => Console.Write(w + " "));
                
        }
    }
}
