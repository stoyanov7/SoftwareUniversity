using System;

namespace _06.Notification
{
    public class Notification
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var result = Console.ReadLine();

                if (result.Equals("success"))
                {
                    var operation = Console.ReadLine();
                    var message = Console.ReadLine();
                    ShowSuccess(operation, message);
                }
                else if (result.Equals("error"))
                {
                    var operation = Console.ReadLine();
                    var code = int.Parse(Console.ReadLine());
                    ShowError(operation, code);
                }
                else
                {
                    continue;
                }
            }
        }

        private static void ShowSuccess(string operation, string message)
        {
            Console.WriteLine($"Successfully executed {operation}.");
            Console.WriteLine("==============================");
            Console.WriteLine($"Message: { message}.");
        }

        private static void ShowError(string operation, int code)
        {
            Console.WriteLine($"Error: Failed to execute {operation}.");
            Console.WriteLine("==============================");
            Console.WriteLine($"Error Code: {code}.");

            if (code > 0)
            {
                Console.WriteLine("Reason: Invalid Client Data.");
            }
            else
            {
                Console.WriteLine("Reason: Internal System Failure.");
            }
        }
    }

}