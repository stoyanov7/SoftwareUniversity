using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AppendLists
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split('|').ToList();
        input.Reverse();
        var result = new List<string>();

        foreach (var lines in input)
        {
            var numbers = lines.Split(' ').ToList();

            foreach (var number in numbers)
            {
                if (number != "")
                {
                    result.Add(number);
                }
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}