﻿namespace DetailPrinter
{
    public class Employee
    {
        public Employee(string name) => this.Name = name;

        public string Name { get; private set; }

        public override string ToString() => this.Name;
    }
}
