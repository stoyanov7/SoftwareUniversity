﻿namespace _02.OldestFamilyMember
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString() => $"{this.Name} {this.Age}";
    }
}