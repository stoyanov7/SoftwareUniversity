namespace UrlDecoder
{
    using System;
    using System.Net;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var encodedUrl = Console.ReadLine();
            var decodeUrl = WebUtility.UrlDecode(encodedUrl);

            Console.WriteLine(decodeUrl);
        }
    }
}
