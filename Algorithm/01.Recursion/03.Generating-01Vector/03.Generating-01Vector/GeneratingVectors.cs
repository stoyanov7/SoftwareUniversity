using System;

namespace _03.Generating_01Vector
{
    public class GeneratingVectors
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter size for a vector: ");
            var size = int.Parse(Console.ReadLine());
            var vector = new int[size];

            Generate01(vector, size - 1);
            Console.WriteLine($"\nCounter = {counter}");
        }

        private static int counter = 0;

        private static void PrintVector(int[] v)
        {
            foreach (var i in v)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        private static void Generate01(int[] vector, int index)
        {
            if (index == -1)
            {
                PrintVector(vector);
                return;
            }

            counter++;

            for (var i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Generate01(vector, index - 1);
            }

        }
    }
}