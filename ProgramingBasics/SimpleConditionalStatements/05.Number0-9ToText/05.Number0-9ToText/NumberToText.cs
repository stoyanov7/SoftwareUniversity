using System;

namespace _05.NumberToText
{
    public class NumberToText
    {
        public static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var result = string.Empty;

            switch (num)
            {
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eigth";
                    break;
                case 9:
                    result = "nini";
                    break;
                default:
                    result = "number too big";
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
