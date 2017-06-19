using System;

namespace _04.GeneratingCombination
{
    public class GeneratingCombination 
    {
        public static void Main(string[] args)
        {
            var wrongInput = true;

            while (wrongInput)
            {
                try
                {
                    Console.Write("Enter size: ");
                    var n = int.Parse(Console.ReadLine());
                    var arr = new int[n];

                    Console.Write("Enter start number: ");
                    var startNum = int.Parse(Console.ReadLine());

                    Console.Write("Enter end number: ");
                    var endNum = int.Parse(Console.ReadLine());

                    GenerateCombinations(arr, 0, startNum, endNum);
                    wrongInput = false;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Array cannot be with negative size!");
                }
            }
        }

        private static void PrintVector(int[] arr)
        {
            Console.Write("{ ");

            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("}");
            Console.WriteLine();
        }

        private static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
        {
            if (arr.Length == index)
            {
                PrintVector(arr);
            }
            else
            {
                for (var i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index + 1, i + 1, endNum);
                }
            }
        }
    }
}
