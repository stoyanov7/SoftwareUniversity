namespace ComparingObjects.Models
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            var comparator = this.Name.CompareTo(other.Name);

            if (comparator == 0)
            {
                comparator = this.Age.CompareTo(other.Age);
            }

            if (comparator == 0)
            {
                comparator = this.Town.CompareTo(other.Town);
            }

            return comparator;
        }
    }
}