namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Factories;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var animals = new List<IAnimal>();

            string firstLine;
            while ((firstLine = Console.ReadLine()) != "End")
            {
                var animalArgs = firstLine.Split();
                var foodArgs = Console.ReadLine().Split();

                try
                {
                    var currentAnimal = AnimalFactory.ProduceAnimal(animalArgs);
                    animals.Add(currentAnimal);

                    var currentFood = FoodFactory.ProduceFood(foodArgs);

                    Console.WriteLine(currentAnimal.ProduceSound());
                    currentAnimal.IncreaseWeight(currentFood);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}