namespace _06.ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main(string[] args)
        {
            var regex = new Regex(@"^[\w-]{3,16}$");
            var text = string.Empty;

            while ((text = Console.ReadLine()) != "END")
            {
                Console.WriteLine(regex.IsMatch(text) ? "valid" : "invalid");
            }
        }
    }
}