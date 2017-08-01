namespace _05.BooleanVariable
{
    using System;

    public class BooleanVariable
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = Convert.ToBoolean(input);

            Console.WriteLine(result ? "Yes" : "No");
        }
    } 
}