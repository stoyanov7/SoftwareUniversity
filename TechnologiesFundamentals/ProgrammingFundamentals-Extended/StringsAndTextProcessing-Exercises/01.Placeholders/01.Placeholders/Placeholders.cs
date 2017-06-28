namespace _01.Placeholders
{
    using System;
    using System.Linq;

    public class Placeholders
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine();

            while (line != "end")
            {
                var lineTokens = line
                    .Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var sentece = lineTokens[0];
                var elements = lineTokens[1]
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (var i = 0; i < elements.Length; i++)
                {
                    var currentPlaceholder = "{" + i + "}";
                    sentece = sentece.Replace(currentPlaceholder, elements[i]);
                }

                Console.WriteLine(sentece);

                line = Console.ReadLine();
            }
        }
    }
}
