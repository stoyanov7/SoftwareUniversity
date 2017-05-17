using System;

namespace _14.ASCIIString
{
    public class ASCIIString
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = "";

            for (int i = 0; i < n; i++)
            {
                var ASCIICode = int.Parse(Console.ReadLine());
                result += (char)ASCIICode;
            }

            Console.WriteLine(result);
        }
    }
}
