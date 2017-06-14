using System;

namespace _09.PasswordGuess
{
    public class PasswordGuess
    {
        public static void Main(string[] args)
        {
            const string password = "s3cr3t!P@ssw0rd";
            var input = Console.ReadLine();

            if (input == password)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
