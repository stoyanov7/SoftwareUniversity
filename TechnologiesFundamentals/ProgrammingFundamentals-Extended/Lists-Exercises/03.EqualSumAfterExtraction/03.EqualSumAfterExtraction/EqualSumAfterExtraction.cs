using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EqualSumAfterExtraction
{
    public class EqualSumAfterExtraction
    {
        public static void Main(string[] args)
        {
            var firstList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var secondList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            foreach (var element in firstList)
            {
                secondList.Remove(element);
            }

            var sumFirsList = firstList.Sum();
            var sumSecondList = secondList.Sum();

            var difference = Math.Abs(sumFirsList - sumSecondList);

            if (sumFirsList == sumSecondList)
            {
                Console.WriteLine($"Yes. Sum: {sumFirsList}");
            }
            else
            {
                Console.WriteLine($"No. Diff: {difference}");
            }
        }
    }
}
