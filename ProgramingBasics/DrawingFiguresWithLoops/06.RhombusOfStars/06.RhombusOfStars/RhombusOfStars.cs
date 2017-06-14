using System;
using System.Text;

namespace _06.RhombusOfStars
{
    public class RhombusOfStars
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var spaces = n - 1;

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(RepeatStr(" ", spaces - i));
                Console.WriteLine(RepeatStr("* ", i + 1));
                Console.WriteLine();
            }

            for (int i = n - 2; i >= 0; i--)
            {
                Console.WriteLine(RepeatStr(" ", spaces - i));
                Console.WriteLine(RepeatStr("* ", i + 1));
                Console.WriteLine();
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
