namespace _03.LastKNumbersSums
{
    using System;
    using System.Linq;

    public class LastKNumbersSums
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var numberArray = new long[n];
            numberArray[0] = 1;

            for (var i = 1; i < n; i++)
            {
                var sum = 0L;

                for (var previous = i - k; previous <= i - 1; previous++)
                {
                    if (previous >= 0)
                    {
                        sum += numberArray[previous];
                    }
                }

                numberArray[i] = sum;
            }

            numberArray
                .ToList()
                .ForEach(Console.WriteLine);
        }
    } 
}