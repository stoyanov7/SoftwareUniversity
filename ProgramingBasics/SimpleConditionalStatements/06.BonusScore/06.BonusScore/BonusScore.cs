using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BonusScore
{
    public class BonusScore
    {
        public static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var bonusScore = 0d;

            if (num <= 100)
            {
                bonusScore = 5;
            }
            else if (num > 1000)
            {
                bonusScore = 0.1 * num;
            }
            else if (num > 100)
            {
                bonusScore = 0.2 * num;
            }

            if (num % 2 == 0)
            {
                bonusScore += 1;
            }
            else if (num % 10 == 5)
            {
                bonusScore += 2;
            }

            Console.WriteLine(bonusScore);
            Console.WriteLine(num + bonusScore);
        }
    }
}
