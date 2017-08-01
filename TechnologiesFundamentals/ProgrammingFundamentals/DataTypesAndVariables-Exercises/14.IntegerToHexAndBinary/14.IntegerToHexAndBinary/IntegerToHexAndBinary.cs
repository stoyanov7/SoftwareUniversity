namespace _14.IntegerToHexAndBinary
{
    using System;

    public class IntegerToHexAndBinary
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(n, 16).ToUpper());
            Console.WriteLine(Convert.ToString(n, 2));
        }
    } 
}