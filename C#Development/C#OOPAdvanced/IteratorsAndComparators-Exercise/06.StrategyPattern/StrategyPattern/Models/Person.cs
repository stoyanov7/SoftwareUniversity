namespace StrategyPattern.Models
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
        
        public int CompareTo(Person other)
        {
            var comparator = this.Name.CompareTo(other.Name);

            if (comparator == 0)
            {
                comparator = this.Age.CompareTo(other.Age);
            }

            return comparator;
        }

        public override string ToString() => $"{this.Name} {this.Age}";
    }
}