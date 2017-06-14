using System;
using System.Text;

namespace _03.SquareOfStars
{
    public class SquareOfStars
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine($"* {RepeatStr(" *", n - 1)}");
            }
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