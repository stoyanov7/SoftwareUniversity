namespace _07.GreaterOfTwoValues
{
    using System;

    public class GreaterOfTwoValues
    {
        public static void Main(string[] args)
        {
            var type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    var firstInt = int.Parse(Console.ReadLine());
                    var secondInt = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstInt, secondInt));
                    break;
                case "char":
                    var firstChar = char.Parse(Console.ReadLine());
                    var secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar));
                    break;
                case "string":
                    var firstString = Console.ReadLine();
                    var secondString = Console.ReadLine();
                    Console.WriteLine(GetMax(firstString, secondString));
                    break;
            }
        }

        private static int GetMax(int first, int second) => first >= second ? first : second;

        private static char GetMax(char first, char second) => (char)GetMax((int)first, (int)second);

        private static string GetMax(string first, string second) => first.CompareTo(second) >= 0 ? first : second;
    } 
}