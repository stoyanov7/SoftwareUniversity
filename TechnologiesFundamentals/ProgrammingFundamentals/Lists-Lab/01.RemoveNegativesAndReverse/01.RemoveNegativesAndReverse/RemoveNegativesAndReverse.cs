namespace _01.RemoveNegativesAndReverse
{
    using System;
    using System.Linq;

    public class RemoveNegativesAndReverse
    {
        public static void Main(string[] args)
        {
            var numberList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            numberList.RemoveAll(x => x < 0);
            numberList.Reverse();

            Console.WriteLine(numberList.Count <= 0 ? "empty" : string.Join(" ", numberList));
        }
    } 
}