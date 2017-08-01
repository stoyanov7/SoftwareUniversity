namespace _03.SumAdjacentEqualNumbers
{
    using System;
    using System.Linq;

    public class SumAdjacentEqualNumbers
    {
        public static void Main(string[] args)
        {
            var numberList = Console.ReadLine()
                .Split(' ')
                .Select(decimal.Parse)
                .ToList();

            for (var i = 0; i < numberList.Count - 1; i++)
            {
                if (numberList[i] == numberList[i + 1])
                {
                    numberList[i] = numberList[i] + numberList[i + 1];
                    numberList.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numberList));
        }
    } 
}