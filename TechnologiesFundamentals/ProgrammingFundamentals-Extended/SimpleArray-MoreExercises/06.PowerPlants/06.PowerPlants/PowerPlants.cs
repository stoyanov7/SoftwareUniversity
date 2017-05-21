using System;
using System.Linq;

namespace _06.PowerPlants
{
    public class PowerPlants
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var day = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    numbers[i]++;
                }

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] != 0)
                    {
                        numbers[j]--;
                    }
                }

                day++;

                var sum = 0;

                for (int k = 0; k < numbers.Length; k++)
                {
                    sum += numbers[k];
                }

                if (sum > 0)
                {
                    if (i == numbers.Length - 1)
                    {
                        for (int k = 0; k < numbers.Length; k++)
                        {
                            if (numbers[k] > 0)
                            {
                                numbers[k]++;
                            }
                        }

                        i = -1;
                    }

                    continue;
                }
                else
                {
                    Console.WriteLine("survived {0} days ({1} season)", day + 1, day / numbers.Length);
                    break;
                }
            }
        }
    }
}