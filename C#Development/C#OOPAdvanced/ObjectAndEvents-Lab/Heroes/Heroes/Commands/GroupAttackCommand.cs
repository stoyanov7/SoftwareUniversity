namespace Heroes.Commands
{
    using Contracts;
    using Models.Contracts;

    public class GroupAttackCommand : ICommand
    {
        private readonly IAttackGroup attackGroup;

        public GroupAttackCommand(IAttackGroup attackGroup) => this.attackGroup = attackGroup;

        public void Execute() => this.attackGroup.GroupAttack();
    }
}