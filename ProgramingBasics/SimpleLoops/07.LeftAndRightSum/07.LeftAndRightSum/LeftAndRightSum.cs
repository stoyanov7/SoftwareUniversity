using System;

namespace _07.LeftAndRightSum
{
    public class LeftAndRightSum
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var leftInput = 0;
            var rightInput = 0;
            var leftSum = 0;
            var rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                leftInput = int.Parse(Console.ReadLine());
                leftSum += leftInput;
            }

            for (int j = 0; j < n; j++)
            {
                rightInput = int.Parse(Console.ReadLine());
                rightSum += rightInput;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes sum {leftSum}");
            }
            else
            {
                Console.WriteLine($"No diff {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}
