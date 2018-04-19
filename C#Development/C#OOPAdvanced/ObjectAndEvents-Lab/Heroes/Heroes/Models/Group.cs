namespace Heroes.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Group : IAttackGroup
    {
        private readonly IList<IAttacker> attackers;

        public Group() => this.attackers = new List<IAttacker>();

        public void AddMember(IAttacker attacker)
        {
            if (attacker != null)
            {
                this.attackers.Add(attacker);
            }

            throw new ArgumentNullException();
        }

        public void GroupTarget(ITarget target)
        {
            foreach (var attacker in this.attackers)
            {
                attacker.SetTarget(target);
            }
        }

        public void GroupAttack()
        {
            foreach (var attacker in this.attackers)
            {
                attacker.Attack();
            }
        }

        public void GroupTargetAndAttack(ITarget target)
        {
            this.GroupTarget(target);
            this.GroupAttack();
        }
    }
}