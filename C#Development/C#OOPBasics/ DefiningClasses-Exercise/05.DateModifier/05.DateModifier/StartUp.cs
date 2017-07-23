namespace _05.DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var firstDateAsStr = Console.ReadLine();
            var secondDateAsStr = Console.ReadLine();
            var result = DateModifier.GetDaysBetweenTwoDates(firstDateAsStr, secondDateAsStr);

            Console.WriteLine(result);
        }
    }
}