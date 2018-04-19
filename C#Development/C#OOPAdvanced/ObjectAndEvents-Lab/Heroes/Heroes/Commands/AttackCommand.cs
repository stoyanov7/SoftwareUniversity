namespace Heroes.Commands
{
    using Contracts;
    using Models.Contracts;

    public class AttackCommand : ICommand
    {
        private readonly IAttacker attacker;

        public AttackCommand(IAttacker attacker) => this.attacker = attacker;

        public void Execute() => this.attacker.Attack();
    }
}