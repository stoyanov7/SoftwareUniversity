using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Altitude
{
    public class Altitude
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .ToArray();

            var altitude = double.Parse(input[0]);

            for (var i = 1; i < input.Length - 1; i+= 2)
            {
                var direction = input[i];
                var value = double.Parse(input[i + 1]);

                if (direction.Equals("up"))
                {
                    altitude += value;
                }
                else
                {
                    altitude -= value;
                }

                if (altitude <= 0)
                {
                    Console.WriteLine("crashed");
                    return;
                }
            }

            Console.WriteLine($"got through safely. current altitude: {altitude}m");
        }
    }
}
