namespace _04.NumbersInReversedOrder
{
    using System;

    public class NumbersInReversedOrder
    {
        public static void Main(string[] args)
        {
            var number = Console.ReadLine();
            ReverseNumber(number);
        }

        private static void ReverseNumber(string number)
        {
            for (var i = number.Length - 1; i >= 0; i--)
            {
                Console.Write(number[i]);
            }
        }
    } 
}