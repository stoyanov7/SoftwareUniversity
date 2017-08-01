namespace _03.PracticeCharsAndStrings
{
    using System;

    public class PracticeCharsAndStrings
    {
        public static void Main(string[] args)
        {
            var firstInput = Console.ReadLine();
            var secondInput = char.Parse(Console.ReadLine());
            var thirdInput = char.Parse(Console.ReadLine());
            var fourthInput = char.Parse(Console.ReadLine());
            var fifthInput = Console.ReadLine();

            Console.WriteLine($"{firstInput}\n{secondInput}\n{thirdInput}\n{fourthInput}\n{fifthInput}");
        }
    } 
}