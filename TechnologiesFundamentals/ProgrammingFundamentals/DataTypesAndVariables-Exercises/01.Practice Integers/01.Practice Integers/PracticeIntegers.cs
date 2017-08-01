namespace _01.Practice_Integers
{
    using System;

    public class PracticeIntegers
    {
        public static void Main(string[] args)
        {
            var firstNumber = sbyte.Parse(Console.ReadLine());
            var secondNumber = byte.Parse(Console.ReadLine());
            var thirdNumber = short.Parse(Console.ReadLine());
            var forthNumber = ushort.Parse(Console.ReadLine());
            var fifthNumber = uint.Parse(Console.ReadLine());
            var sixtNumber = int.Parse(Console.ReadLine());
            var seventhNumber = long.Parse(Console.ReadLine());

            Console.WriteLine($"{firstNumber}\n{secondNumber}\n{thirdNumber}\n{forthNumber}\n{fifthNumber}\n{sixtNumber}\n{seventhNumber}");
        }
    } 
}