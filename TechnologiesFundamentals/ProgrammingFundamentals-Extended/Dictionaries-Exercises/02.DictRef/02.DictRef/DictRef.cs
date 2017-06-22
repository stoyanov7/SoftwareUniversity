using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.DictRef
{
    public class DictRef
    {
        public static void Main(string[] args)
        {
            var dictRef = new Dictionary<string, int>();
            var line = Console.ReadLine();

            while (line != "end")
            {
                ReadLine(dictRef, line);
                line = Console.ReadLine();
            }

            foreach (var kvp in dictRef)
            {
                Console.WriteLine($"{kvp.Key} === {kvp.Value}");
            }
        }

        private static void ReadLine(Dictionary<string, int> dictRef, string line)
        {
            var lineToken = line
                .Split('=')
                .Select(x => x.Trim())
                .ToArray();

            var key = lineToken[0];
            var valueAsStr = lineToken[1];
            var isDigit = int.TryParse(valueAsStr, out int valueAsNumber);

            if (isDigit)
            {
                if (!dictRef.ContainsKey(key))
                {
                    dictRef.Add(key, 0);
                }

                dictRef[key] = valueAsNumber;
            }
            else
            {
                if (dictRef.ContainsKey(valueAsStr))
                {
                    if (!dictRef.ContainsKey(key))
                    {
                        dictRef.Add(key, 0);
                    }

                    dictRef[key] = dictRef[valueAsStr];
                }
            }
        }
    }
}
