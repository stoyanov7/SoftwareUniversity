namespace _03.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinaryConverter
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var decimalNumber = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
            }
            else
            {

                while (number > 0)
                {
                    decimalNumber.Push(number % 2);
                    number /= 2;
                }
            }

            while (decimalNumber.Count > 0)
            {
                Console.Write(decimalNumber.Pop());
            }
        }
    }
}