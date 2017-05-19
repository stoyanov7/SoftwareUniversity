using System;

namespace _04.RotateArrayOfStrings
{
    public class RotateArrayOfStrings
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();

            Console.Write(words[words.Length - 1]);

            for (int i = 0; i < words.Length - 1; i++)
            {
                Console.Write(" " + words[i]);
            }
        }
    }
}
