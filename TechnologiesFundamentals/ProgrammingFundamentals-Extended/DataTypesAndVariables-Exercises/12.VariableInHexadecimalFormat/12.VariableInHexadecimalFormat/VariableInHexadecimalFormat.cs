using System;

namespace _12.VariableInHexadecimalFormat
{
    public class VariableInHexadecimalFormat
    {
        public static void Main(string[] args)
        {
            var variable = Console.ReadLine();
            Console.WriteLine(Convert.ToInt32(variable, 16));
        }
    }
}
