using System;
using System.Linq;

namespace _08.ArraySymmetry
{
    public class ArraySymmetry
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var isSymetric = true;

            for (int i = 0; i < arr.Length / 2; i++)
            {
                var firstWord = arr[0];
                var secondWord = arr[arr.Length - 1 - i];

                if (firstWord != secondWord)
                {
                    isSymetric = false;
                    break;
                }
            }

            Console.WriteLine(isSymetric ? "Yes" : "No");
        }
    }
}
