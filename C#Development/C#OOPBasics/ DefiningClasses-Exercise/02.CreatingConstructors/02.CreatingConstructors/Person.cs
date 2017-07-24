namespace _02.CreatingConstructors
{
    using System;

    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age) : this()
        {
            this.Age = age;
        }

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
    }
}