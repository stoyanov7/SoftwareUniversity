namespace _01.HelloName
{
    using System;

    public class HelloName
    {
        public static void Main(string[] args)
        {
            var name = Console.ReadLine();
            PrintName(name);
        }

        private static void PrintName(string name) => Console.WriteLine($"Hello, {name}!");
    } 
}