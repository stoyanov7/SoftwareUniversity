namespace _15.Substring
{
    using System;

    public class Substring
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var jump = int.Parse(Console.ReadLine());

            const char Search = 'p';
            var hasMatch = false;

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == Search)
                {
                    hasMatch = true;

                    var endIndex = i + jump;
                    var matchedString = string.Empty;

                    if (endIndex > text.Length - jump)
                    {
                        endIndex = text.Length - 1;
                        matchedString = text.Substring(i);
                    }
                    else
                    {
                        matchedString = text.Substring(i, jump + 1);
                    }

                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}