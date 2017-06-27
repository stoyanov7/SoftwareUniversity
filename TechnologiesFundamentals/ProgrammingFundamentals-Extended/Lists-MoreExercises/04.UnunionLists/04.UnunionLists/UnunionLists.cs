namespace _04.UnunionLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UnunionLists
    {
        public static void Main(string[] args)
        {
            var inputList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var currentInputList = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

                var tempList = new List<int>();

                GetUniqueElements(inputList, currentInputList, tempList);
                GetUniqueElements(currentInputList, inputList, tempList);

                inputList = tempList;
            }

            inputList.Sort();
            Console.WriteLine(string.Join(" ", inputList));
        }

        private static void GetUniqueElements(List<int> primalList, List<int> currentArr, List<int> tempList)
        {
            for (var i = 0; i < primalList.Count; i++)
            {
                var num = primalList[i];

                if (!currentArr.Contains(num))
                {
                    tempList.Add(primalList[i]);
                }
            }
        }
    }
}
