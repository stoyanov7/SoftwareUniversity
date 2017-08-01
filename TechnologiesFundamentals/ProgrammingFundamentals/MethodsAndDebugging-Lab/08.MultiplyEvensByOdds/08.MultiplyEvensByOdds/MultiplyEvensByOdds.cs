namespace _08.MultiplyEvensByOdds
{
    using System;

    public class MultiplyEvensByOdds
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultiplyOfEvenAndOdds(number));
        }

        private static int GetMultiplyOfEvenAndOdds(int number) => Math.Abs(GetSumOfOddDigits(number) * GetSumOfEvenGidits(number));

        private static int GetSumOfOddDigits(int number) => GetSumOfDigits(number, 1);

        private static int GetSumOfEvenGidits(int number) => GetSumOfDigits(number, 0);

        private static int GetSumOfDigits(int number, int remainder)
        {
            var result = 0;

            foreach (var symbol in number.ToString())
            {
                var digit = symbol - '0';

                if (digit % 2 == remainder)
                {
                    result += digit;
                }
            }

            return result;
        }
    } 
}