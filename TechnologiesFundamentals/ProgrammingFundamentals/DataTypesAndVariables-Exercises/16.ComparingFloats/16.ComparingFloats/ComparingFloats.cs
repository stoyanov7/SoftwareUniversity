namespace _16.ComparingFloats
{
    using System;

    public class ComparingFloats
    {
        public static void Main(string[] args)
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());
            const double eps = 0.000001;

            Console.WriteLine(Math.Abs(firstNumber - secondNumber) < eps ? "True" : "False");
        }
    } 
}