namespace _07.ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidTime
    {
        public static void Main(string[] args)
        {
            var regex = new Regex(@"\b(0?[0-9]|1[0-2])(:[0-5]?[0-9]){2}\s?(A|P)M\b");
            var time = string.Empty;

            while ((time = Console.ReadLine()) != "END")
            {
                Console.WriteLine(regex.IsMatch(time) ? "valid" : "invalid");
            }
        }
    }
}