namespace _17.PrintPartOfASCIITable
{
    using System;

    public class PrintPartOfASCIITable
    {
        public static void Main(string[] args)
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            for (var i = start; i <= end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    } 
}