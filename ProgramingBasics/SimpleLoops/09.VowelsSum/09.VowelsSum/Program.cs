using System;

namespace _09.VowelsSum
{
    public class VowelsSum
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .ToLower();

            var vowelsSum = 0;

            for (var i = 0; i < text.Length; i++)
            {
                var letter = text[i];

                switch (letter)
                {
                    case 'a':
                        vowelsSum += 1;
                        break;
                    case 'e':
                        vowelsSum += 2;
                        break;
                    case 'i':
                        vowelsSum += 3;
                        break;
                    case 'o':
                        vowelsSum += 4;
                        break;
                    case 'u':
                        vowelsSum += 5;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(vowelsSum);
        }
    }
}