using System;

namespace _07.GreaterOfTwoValues
{
    public class GreaterOfTwoValues
    {
        public static void Main(string[] args)
        {

            var type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    var a = int.Parse(Console.ReadLine());
                    var b = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(a, b));
                    break;
                case "char":
                    var c = char.Parse(Console.ReadLine());
                    var d = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(c, d));
                    break;
                case "string":
                    var e = Console.ReadLine();
                    var f = Console.ReadLine();
                    Console.WriteLine(GetMax(e, f));
                    break;
            }
        }

        private static int GetMax(int a, int b)
        {
            return a >= b ? a : b;
        }

        private static char GetMax(char a, char b)
        {
            return a >= b ? a : b;
        }

        private static string GetMax(string a, string b)
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }
    }
}
