using System;
using System.Collections.Generic;

namespace _03.RecordUniqueNames
{
    public class RecordUniqueNames
    {
        public static void Main(string[] args)
        {
            var names = new HashSet<string>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentName = Console.ReadLine();
                names.Add(currentName);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
