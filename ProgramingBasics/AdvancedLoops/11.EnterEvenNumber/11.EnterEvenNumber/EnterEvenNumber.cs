using System;

namespace _11.EnterEvenNumber
{
    public class EnterEvenNumber
    {
        public static void Main(string[] args)
        {
            var n = 0;

            do
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n % 2 == 0)
                    {
                        break;
                    }

                    Console.WriteLine("The number is even.");
                    n = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid number!");
                }
            } while (true);

            Console.WriteLine($"Even number entered: {n}");
        }
    }
}