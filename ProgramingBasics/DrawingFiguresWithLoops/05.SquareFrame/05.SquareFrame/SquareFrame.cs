using System;
using System.Text;

namespace _05.SquareFrame
{
    public class SquareFrame
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine($"+ {RepeatStr(" -", n - 2)} +");

            for (var i = 0; i < n - 2; i++)
            {
                Console.WriteLine("|" + RepeatStr(" -", n - 2) + " |");
            }

            Console.WriteLine("+" + RepeatStr(" -", n - 2) + " +");
        }

        private static string RepeatStr(string str, int count)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }
    }
}
