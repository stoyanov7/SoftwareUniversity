namespace BarrackWars.Models
{
    using System;
    using Contracts;

    public class Unit : IUnit
    {
        private int health;
        private int attackDamage;

        protected Unit(int health, int attackDamage)
        {
            this.SetInitialHealth(health);
            this.AttackDamage = attackDamage;
        }

        public int AttackDamage
        {
            get => this.attackDamage;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Attack damage should be positive.");
                }

                this.attackDamage = value;
            }
        }

        public int Health
        {
            get => this.health;

            set => this.health = value < 0 ? 0 : value;
        }

        private void SetInitialHealth(int newHealth)
        {
            if (newHealth <= 0)
            {
                throw new ArgumentException("Initial health should be positive.");
            }

            this.Health = newHealth;
        }
    }
}
