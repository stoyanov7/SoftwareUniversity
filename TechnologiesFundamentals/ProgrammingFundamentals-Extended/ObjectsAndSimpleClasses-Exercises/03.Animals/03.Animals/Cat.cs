namespace _03.Animals
{
    using System;

    public class Cat
    {
        public Cat(string name, int age, int intelligeceQuotient)
        {
            this.Name = name;
            this.Age = age;
            this.IntelligenceQuotient = intelligeceQuotient;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int IntelligenceQuotient { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
        }
    }
}
