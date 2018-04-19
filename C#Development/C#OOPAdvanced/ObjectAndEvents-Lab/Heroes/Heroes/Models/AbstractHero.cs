namespace Heroes.Models
{
    using System;
    using Contracts;

    public abstract class AbstractHero : IAttacker
    {
        private const string TARGET_NULL_MESSAGE = "Target is null!";
        private const string NO_TARGET_MESSAGE = "{0} has no target";
        private const string TARGET_DEAD_MESSAGE = "{0} is dead";
        private const string SET_TARGET_MESSAGE = "{0} targets {1}";

        private readonly string id;
        private readonly int damage;
        private ITarget target;

        protected AbstractHero(string id, int damage)
        {
            this.id = id;
            this.damage = damage;
        }

        public void Attack()
        {
            if (this.target == null)
            {
                Console.WriteLine(NO_TARGET_MESSAGE, this);
            }
            else if (this.target.IsDead)
            {
                Console.WriteLine(TARGET_DEAD_MESSAGE, this.target);
            }
            else
            {
                this.ExecuteClassSpecificAttack(this.target, this.damage);
            }
        }

        public void SetTarget(ITarget newTarget)
        {
            if (newTarget == null)
            {
                Console.WriteLine(TARGET_NULL_MESSAGE);
            }
            else
            {
                this.target = newTarget;
                Console.WriteLine(SET_TARGET_MESSAGE, this, this.target);
            }
        }

        public override string ToString() => this.id;

        protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);
    }
}