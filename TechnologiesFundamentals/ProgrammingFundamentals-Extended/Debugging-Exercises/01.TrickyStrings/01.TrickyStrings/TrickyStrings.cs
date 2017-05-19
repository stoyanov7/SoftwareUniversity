using System;

namespace _01.TrickyStrings
{
    public class TrickyStrings
    {
        public static void Main(string[] args)
        {
            var delimeter = Console.ReadLine();
            var numberOfStrings = int.Parse(Console.ReadLine());
            var result = string.Empty;

            for (var i = 0; i < numberOfStrings; i++)
            {
                if (i < numberOfStrings - 1)
                {
                    result += Console.ReadLine() + delimeter;
                    continue;
                }

                result += Console.ReadLine();
            }

            Console.WriteLine(result);
        }
    }
}