namespace _05.ConcatenateStrings
{
    using System;
    using System.Text;

    public class ConcatenateStrings
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder(n);

            for (int i = 0; i < n; i++)
            {
                sb.Append($"{Console.ReadLine()} ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
