namespace _03.Animals
{
    using System;

    public class Dog
    {
        public Dog(string name, int age, int numberOfLegs)
        {
            this.Name = name;
            this.Age = age;
            this.NumberOfLegs = numberOfLegs;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int NumberOfLegs { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
        }
    }
}
