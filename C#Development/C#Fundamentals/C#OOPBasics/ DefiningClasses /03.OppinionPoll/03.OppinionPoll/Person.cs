using System;

namespace _03.OppinionPoll
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Person p) => this.Name.CompareTo(p.Name);
    }
}
