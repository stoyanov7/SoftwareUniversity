namespace Animals
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>
            {
                new Cat("Pesho", "Whiskas"),
                new Dog("Gosho", "Meat")
            };

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ExplainSelf());
            }
        }
    }
}
