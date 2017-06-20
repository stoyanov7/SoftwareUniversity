namespace _03.Animals
{
    using System;

    public class Snake
    {
        public Snake(string name, int age, int crueltyCoefficient)
        {
            this.Name = name;
            this.Age = age;
            this.CrueltyCoefficient = crueltyCoefficient;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CrueltyCoefficient { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
        }
    }
}
