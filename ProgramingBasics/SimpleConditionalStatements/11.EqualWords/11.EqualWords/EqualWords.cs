using System;

namespace _11.EqualWords
{
    public class EqualWords
    {
        public static void Main(string[] args)
        {
            var input1 = Console.ReadLine().ToLower();
            var input2 = Console.ReadLine().ToLower();

            if (input1 == input2)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
