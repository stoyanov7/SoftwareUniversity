namespace Heroes.Models
{
    using System;
    using Contracts;

    public class Warrior : AbstractHero
    {
        private const string ATTACK_MESSAGE = "{0} damages {1} for {2}";

        private IHandler logger;

        public Warrior(string id, int damage, IHandler logger)
            : base(id, damage)
        {
            this.logger = logger;
        }

        protected override void ExecuteClassSpecificAttack(ITarget target, int damage)
        {
            Console.WriteLine(ATTACK_MESSAGE, this, target, damage);
        }
    }
}