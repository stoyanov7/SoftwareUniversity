namespace _06.ReverseArrayOfStrings
{
    using System;
    using System.Linq;

    public class ReverseArrayOfStrings
    {
        public static void Main(string[] args)
        {
            var stringArray = Console.ReadLine()
                .Split(' ')
                .ToArray();

            for (var i = stringArray.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(stringArray[i] + " ");
            }
        }
    } 
}