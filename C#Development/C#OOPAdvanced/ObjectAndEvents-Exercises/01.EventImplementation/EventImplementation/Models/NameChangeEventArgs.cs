namespace EventImplementation.Models
{
    using System;
    using Contracts;

    public class NameChangeEventArgs : EventArgs, INameChangeEventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}