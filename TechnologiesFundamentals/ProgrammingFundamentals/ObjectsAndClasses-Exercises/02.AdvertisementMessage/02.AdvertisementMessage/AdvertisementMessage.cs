using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdvertisementMessage
{
    public static void Main(string[] args)
    {
        var phrases = new string[]
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can’t live without this product."
        };

        var events = new string[]
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };

        var author = new string[]
        {
           "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
        };

        var cities = new string[]
        {
            "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
        };

        var n = int.Parse(Console.ReadLine());
        var random = new Random();

        for (int i = 0; i < n; i++)
        {
            var phraseIndex = random.Next(0, phrases.Length);
            var eventIndex = random.Next(0, events.Length);
            var authorIndex = random.Next(0, author.Length);
            var cityIndex = random.Next(0, cities.Length);
            Console.WriteLine($"{phrases[phraseIndex]} {events[phraseIndex]} {author[authorIndex]} {cities[cityIndex]}");

        }
    }
}