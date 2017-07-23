namespace _04.OpinionPoll
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

        public int CompareTo(Person p) => this.Name.CompareTo(p.Name);

        public override string ToString() => $"{this.Name} - {this.Age}";
    }
}