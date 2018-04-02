namespace EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            var comparison = this.Name.CompareTo(other.Name);

            return comparison == 0
                ? this.Age.CompareTo(other.Age)
                : comparison;
        }
    }
}