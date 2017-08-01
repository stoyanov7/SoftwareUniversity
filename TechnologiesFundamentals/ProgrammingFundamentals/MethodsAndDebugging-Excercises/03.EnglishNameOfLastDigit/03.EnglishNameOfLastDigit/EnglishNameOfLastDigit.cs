namespace _03.EnglishNameOfLastDigit
{
    using System;

    public class EnglishNameOfLastDigit
    {
        public static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());
            Console.WriteLine(GetEnglishNameOfLastDigit(number));
        }

        private static string GetEnglishNameOfLastDigit(long number)
        {
            var lastDigit = Math.Abs(number % 10);
            var message = string.Empty;

            switch (lastDigit)
            {
                case 0:
                    message = "zero";
                    break;
                case 1:
                    message = "one";
                    break;
                case 2:
                    message = "two";
                    break;
                case 3:
                    message = "tree";
                    break;
                case 4:
                    message = "four";
                    break;
                case 5:
                    message = "five";
                    break;
                case 6:
                    message = "six";
                    break;
                case 7:
                    message = "seven";
                    break;
                case 8:
                    message = "eight";
                    break;
                case 9:
                    message = "nine";
                    break;
            }

            return message;
        }
    } 
}