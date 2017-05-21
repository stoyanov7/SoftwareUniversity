using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Phonebook
{
    public class Phonebook
    {
        public static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var names = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var name = Console.ReadLine();

            while (name != "done")
            {
                for (var i = 0; i < names.Length; i++)
                {
                    if (name == names[i])
                    {
                        Console.WriteLine($"{names[i]} -> {phoneNumbers[i]}");
                    }
                }

                name = Console.ReadLine();
            }
        }
    }
}
