namespace _02.ParseURLs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ParseURLs
    {
        public static void Main(string[] args)
        {
            var url = Console.ReadLine()
                .Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (url.Length != 2 || url[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            var protocol = url[0];
            var indexResource = url[1].IndexOf('/');
            var server = url[1].Substring(0, indexResource);
            var resources = url[1].Substring(indexResource + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resources}");
        }
    }
}
