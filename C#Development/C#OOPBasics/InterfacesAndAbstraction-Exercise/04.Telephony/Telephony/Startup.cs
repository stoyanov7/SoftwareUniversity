namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var phoneNumbers = ReadData();
            var smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(phoneNumber));
            }

            var urls = ReadData();

            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }

        private static IEnumerable<string> ReadData() => Console.ReadLine().Split(" ").ToArray();
    }
}