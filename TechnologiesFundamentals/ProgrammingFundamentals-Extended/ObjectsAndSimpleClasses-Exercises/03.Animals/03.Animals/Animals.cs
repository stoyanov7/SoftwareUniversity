namespace _03.Animals
{
    using System;
    using System.Collections.Generic;

    public class Animals
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dog> dogs = new Dictionary<string, Dog>();
            Dictionary<string, Cat> cats = new Dictionary<string, Cat>();
            Dictionary<string, Snake> snakes = new Dictionary<string, Snake>();
            var line = Console.ReadLine();

            while (line != "I'm your Huckleberry")
            {
                var lineTokens = line.Split(' ');
                ReadAnimals(dogs, cats, snakes, lineTokens);

                line = Console.ReadLine();
            }

            foreach (var dog in dogs.Values)
            {
                Console.WriteLine($"Dog: {dog.Name}, Age: {dog.Age}, Number Of Legs: {dog.NumberOfLegs}");
            }

            foreach (var cat in cats.Values)
            {
                Console.WriteLine($"Cat: {cat.Name}, Age: {cat.Age}, IQ: {cat.IntelligenceQuotient}");
            }

            foreach (var snake in snakes.Values)
            {
                Console.WriteLine($"Snake: {snake.Name}, Age: {snake.Age}, Cruelty: {snake.CrueltyCoefficient}");
            }
        }

        private static void ReadAnimals(Dictionary<string, Dog> dogs, Dictionary<string, Cat> cats, Dictionary<string, Snake> snakes, string[] lineTokens)
        {
            if (lineTokens.Length > 2)
            {
                var type = lineTokens[0];
                var name = lineTokens[1];
                var age = int.Parse(lineTokens[2]);
                var parameter = int.Parse(lineTokens[3]);

                switch (type)
                {
                    case "Dog":
                        var newDog = new Dog(name, age, parameter);
                        dogs.Add(newDog.Name, newDog);
                        break;
                    case "Cat":
                        var newCat = new Cat(name, age, parameter);
                        cats.Add(newCat.Name, newCat);
                        break;
                    case "Snake":
                        var newSnake = new Snake(name, age, parameter);
                        snakes.Add(newSnake.Name, newSnake);
                        break;
                }
            }
            else
            {
                var name = lineTokens[1];

                if (dogs.ContainsKey(name))
                {
                    dogs[name].ProduceSound();
                }
                else if (cats.ContainsKey(name))
                {
                    cats[name].ProduceSound();
                }
                else if (snakes.ContainsKey(name))
                {
                    snakes[name].ProduceSound();
                }
            }
        }
    }
}
