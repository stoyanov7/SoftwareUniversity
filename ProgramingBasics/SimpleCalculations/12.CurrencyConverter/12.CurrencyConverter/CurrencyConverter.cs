using System;

namespace _12.CurrencyConverter
{
    public class CurrencyConverter
    {
        private static double BGN_TO_USD = 1.79549;
        private static double BGN_TO_EUR = 1.95583;
        private static double BGN_TO_GBP = 2.53405;

        public static void Main(string[] args)
        {
            var inputValue = double.Parse(Console.ReadLine());
            var inputCurrency = Console.ReadLine().ToUpper();
            var outputCurrency = Console.ReadLine().ToUpper();
            var inputValueInBGN = 0d;

            switch (inputCurrency)
            {
                case "USD":
                    inputValueInBGN = inputValue * BGN_TO_USD;
                    break;

                case "EUR":
                    inputValueInBGN = inputValue * BGN_TO_EUR;
                    break;

                case "GBP":
                    inputValueInBGN = inputValue * BGN_TO_GBP;
                    break;

                default:
                    inputValueInBGN = inputValue;
                    break;
            }

            double outputValue = 0;

            switch (outputCurrency)
            {
                case "BGN":
                    Console.WriteLine($"{inputValueInBGN:F2} {outputCurrency}");
                    break;

                case "USD":
                    outputValue = inputValueInBGN / BGN_TO_USD;
                    Console.WriteLine($"{outputValue:F2} {outputCurrency}");
                    break;

                case "EUR":
                    outputValue = inputValueInBGN / BGN_TO_EUR;
                    Console.WriteLine($"{outputValue} {outputCurrency}");
                    break;

                case "GBP":
                    outputValue = inputValueInBGN / BGN_TO_GBP;
                    Console.WriteLine($"{outputValue} {outputCurrency}");
                    break;
            }
        }
    }
}
