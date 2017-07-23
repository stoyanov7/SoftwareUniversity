﻿namespace _12.Google
{
    public class Pokemon
    {
        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public override string ToString() => $"{this.Name} {this.Type}";
    }
}