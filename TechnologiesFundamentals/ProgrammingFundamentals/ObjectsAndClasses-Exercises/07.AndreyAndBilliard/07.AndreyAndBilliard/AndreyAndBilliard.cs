namespace _07.AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AndreyAndBilliard
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var infoItems = new Dictionary<string, decimal>();
            ReadProductAndPrice(n, infoItems);

            var customers = new List<Customer>();
            var line = string.Empty;
            while ((line = Console.ReadLine()) != "end of clients")
            {
                var infoCustomer = line.Split('-');
                var orderInfo = infoCustomer[1].Split(',');

                if (infoItems.ContainsKey(orderInfo[0]))
                {
                    var customer = new Customer();
                    customer.Name = infoCustomer[0];

                    var piecesProduct = int.Parse(orderInfo[1]);
                    var product = orderInfo[0];

                    if (customers.Any(c1 => c1.Name == infoCustomer[0]))
                    {
                        customer = customers.First(cl => cl.Name == infoCustomer[0]);

                        if (!customer
                            .Order
                            .ContainsKey(product))
                        {
                            customer
                                .Order
                                .Add(product, piecesProduct);

                            customer.Bill += piecesProduct * infoItems[product];
                        }
                        else
                        {
                            customer.Order[product] += piecesProduct;
                            customer.Bill += piecesProduct * infoItems[product];
                        }
                    }
                    else
                    {
                        customer.Order = new Dictionary<string, int>();

                        customer
                            .Order
                            .Add(product, piecesProduct);

                        customer.Bill = piecesProduct * infoItems[product];
                        customers.Add(customer);
                    }
                }
            }

            var sum = 0m;
            foreach (var client in customers.OrderBy(cl => cl.Name))
            {
                Console.WriteLine(client.Name);

                foreach (var item in client.Order)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }

                Console.WriteLine($"Bill: {client.Bill:f2}");

                sum += client.Bill;
            }

            Console.WriteLine($"Total bill: {sum:f2}");
        }

        private static void ReadProductAndPrice(int n, Dictionary<string, decimal> items)
        {
            for (var i = 0; i < n; i++)
            {
                var info = Console.ReadLine()
                    .Split('-')
                    .ToArray();

                var product = info[0];
                var price = decimal.Parse(info[1]);
                items[product] = price;

                if (!items.ContainsKey(product))
                {
                    items.Add(product, price);
                }
                else
                {
                    items[product] = price;
                }
            }
        }
    }
}