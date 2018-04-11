namespace KingsGambit.Models
{
    using System;
    using Contracts;

    public class King : IAttackable
    {
        public event EventHandler UnderAttack;

        public King(string name) => this.Name = name;

        public string Name { get; private set; }

        public void OnUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            this.UnderAttack?.Invoke(this, new EventArgs());
        }
    }
}