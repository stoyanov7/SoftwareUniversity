namespace _05.PizzaCalories
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var pizza = new Pizza();
            var dough = new Dough();

            var line = Console.ReadLine();

            if (line.Contains("Dough"))
            {
                var tokens = line
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var type = tokens[1];
                var tech = tokens[2];
                var weight = double.Parse(tokens[3]);

                try
                {
                    dough = new Dough(type, tech, weight);
                    Console.WriteLine($"{dough.GetCalculateCalories():F2}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                line = Console.ReadLine();

                if (line.Equals("END"))
                {
                    return;
                }
            }

            if (line.Contains("Topping"))
            {
                var tokens = line
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var toppingName = tokens[1];
                var toppingWeight = double.Parse(tokens[2]);

                try
                {
                    var topping = new Topping(toppingName, toppingWeight);
                    Console.WriteLine($"{topping.GetCalculateCalories():F2}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                return;
            }

            while (line != "END")
            {
                var lineTokens = line
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (lineTokens[0])
                {
                    case "Pizza":
                        var name = lineTokens[1];
                        var toppingCount = int.Parse(lineTokens[2]);

                        try
                        {
                            pizza = new Pizza(name, toppingCount);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }

                        break;
                    case "Dough":
                        var type = lineTokens[1];
                        var tech = lineTokens[2];
                        var weight = double.Parse(lineTokens[3]);

                        try
                        {
                            dough = new Dough(type, tech, weight);
                            pizza.Dough = dough;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }

                        break;
                    case "Topping":
                        var toppingName = lineTokens[1];
                        var toppingWeight = double.Parse(lineTokens[2]);

                        try
                        {
                            var topping = new Topping(toppingName, toppingWeight);
                            pizza.Toppings.Add(topping);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }

                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"{pizza.Name} - {pizza.GetCalculateCalories():F2} Calories.");
        }
    }
}