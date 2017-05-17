using System;

namespace _01.PracticeIntegerNumbers
{
    public class PracticeIntegerNumbers
    {
        public static void Main(string[] args)
        {
            sbyte firstNumber = sbyte.Parse(Console.ReadLine());
            byte secondNumber = byte.Parse(Console.ReadLine());
            short thirdNumber = short.Parse(Console.ReadLine());
            ushort forthNumber = ushort.Parse(Console.ReadLine());
            uint fifthNumber = uint.Parse(Console.ReadLine());
            int sixtNumber = int.Parse(Console.ReadLine());
            long seventhNumber = long.Parse(Console.ReadLine());

            Console.WriteLine($"{firstNumber}\n{secondNumber}\n{thirdNumber}\n{forthNumber}\n{fifthNumber}\n{sixtNumber}\n{seventhNumber}");
        }
    }
}
