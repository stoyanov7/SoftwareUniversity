namespace _04.OpinionPoll
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.name = "No name";
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            set
            {
                try
                {
                    this.age = value;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public int CompareTo(Person p) => this.Name.CompareTo(p.Name);

        public override string ToString() => $"{this.Name} - {this.Age}";
    }
}