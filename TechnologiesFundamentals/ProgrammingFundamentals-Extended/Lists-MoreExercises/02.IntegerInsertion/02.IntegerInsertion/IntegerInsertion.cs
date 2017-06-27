using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IntegerInsertion
{
    public class IntegerInsertion
    {
        public static void Main(string[] args)
        {
            var inputList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var numbers = Console.ReadLine();

            while (numbers != "end")
            {
                var firstIndex = int.Parse(numbers.Substring(0, 1));
                inputList.Insert(firstIndex, int.Parse(numbers));

                numbers = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
