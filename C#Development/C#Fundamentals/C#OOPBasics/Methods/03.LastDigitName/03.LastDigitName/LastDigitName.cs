using System;

namespace _03.LastDigitName
{
    public class Number
    {
        public string Digit { get; set; }

        private static string LastDigitAsWord(int n)
        {
            var result = Math.Abs(n % 10);
            var digitAsWord = string.Empty;

            switch (result)
            {
                case 0:
                    digitAsWord = "zero";
                    break;
                case 1:
                    digitAsWord = "one";
                    break;
                case 2:
                    digitAsWord = "two";
                    break;
                case 3:
                    digitAsWord = "three";
                    break;
                case 4:
                    digitAsWord = "four";
                    break;
                case 5:
                    digitAsWord = "five";
                    break;
                case 6:
                    digitAsWord = "six";
                    break;
                case 7:
                    digitAsWord = "seven";
                    break;
                case 8:
                    digitAsWord = "eight";
                    break;
                case 9:
                    digitAsWord = "nine";
                    break;
            }

            return digitAsWord;
        }

        public class LastDigitName
        {
            public static void Main(string[] args)
            {
                var n = int.Parse(Console.ReadLine());

                Console.WriteLine(Number.LastDigitAsWord(n));
            }
        }
    }
}
