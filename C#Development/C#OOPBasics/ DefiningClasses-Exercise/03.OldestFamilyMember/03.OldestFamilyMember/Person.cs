namespace _03.OldestFamilyMember
{
    using System;

    public class Person
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
                if (value <= 0)
                {
                    throw new InvalidOperationException();
                }

                this.age = value;
            }
        }
    }
}