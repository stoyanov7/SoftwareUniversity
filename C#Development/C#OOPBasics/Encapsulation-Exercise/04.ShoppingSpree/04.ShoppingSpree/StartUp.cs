namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people;
            List<Product> products;

            try
            {
                people = new List<Person>(Console.ReadLine()
                    .Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Split('='))
                    .Select(p => new Person(p[0], decimal.Parse(p[1]))));

                products = new List<Product>(Console.ReadLine()
                    .Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Split('='))
                    .Select(p => new Product(p[0], decimal.Parse(p[1]))));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Input have to consist of: Name and Money");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("Money parameter have to be a digit");
                return;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var commands = string.Empty;
            while ((commands = Console.ReadLine()) != "END")
            {
                var commandsTokens = commands
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var person = people
                    .FirstOrDefault(x => x.Name == commandsTokens[0]);

                var product = products
                    .FirstOrDefault(x => x.Name == commandsTokens[1]);

                if (person != null && product != null)
                {
                    if (product.Cost <= person.Money)
                    {
                        person.BagOfProducts.Add(product);
                        person.Money -= product.Cost;

                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }
            }

            foreach (var person in people)
            {
                if (!person.BagOfProducts.Any())
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }

                Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
            }
        }
    }
}