using System;
using System.Globalization;

namespace _13.DaysAfterBirth
{
    public class DaysAfterBirth
    {
        public static void Main(string[] args)
        {
            var userInput = Console.ReadLine();
            var format = "dd-MM-yyyy";
            var userDate = DateTime.ParseExact(userInput, format, CultureInfo.InvariantCulture);
            userDate = userDate.AddDays(999);

            Console.WriteLine(userDate.ToString(format));
        }
    }
}
