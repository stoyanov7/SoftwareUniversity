using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Factorial
{
    public class Factorial
    {
        public static void Main(string[] args)
        {
            bool wrongInput = true;

            while (wrongInput)
            {
                Console.Write("Enter n = ");
                var input = int.Parse(Console.ReadLine());

                try
                {
                    BigInteger result = factorial(input);
                    Console.WriteLine("n! = " + result);
                    wrongInput = false;
                }
                catch (NegativeNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int[] arr = { 1, 2, 3 };
            int sum = findSum(arr, 0);
            Console.WriteLine("{0}", sum);
        }

        private static BigInteger factorial(int num)
        {
            if (num < 0)
                return 0;

            if (num == 0)
                return 1;

            else
                return num * factorial(num - 1);
        }

        private static int findSum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }
            return arr[index] + findSum(arr, index + 1);
        }
    }
}
