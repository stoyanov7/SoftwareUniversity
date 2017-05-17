using System;

namespace _13.DigitsWithWords
{
    public class DigitsWithWords
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(PrintDigitWithWord(input));
        }

        private static int PrintDigitWithWord(string input)
        {
            var result = 0;

            switch (input)
            {
                case "zero":
                    return result;
                case "one":
                    result = 1;
                    break;
                case "two":
                    result = 2;
                    break;
                case "three":
                    result = 3;
                    break;
                case "four":
                    result = 4;
                    break;
                case "five":
                    result = 5;
                    break;
                case "six":
                    result = 6;
                    break;
                case "seven":
                    result = 7;
                    break;
                case "eight":
                    result = 8;
                    break;
                case "nine":
                    result = 9;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}