namespace Heroes.Commands
{
    using Contracts;
    using Models.Contracts;

    public class GroupTargetCommand : ICommand
    {
        private readonly IAttackGroup attackGroup;
        private readonly ITarget target;

        public GroupTargetCommand(IAttackGroup attackGroup, ITarget target)
        {
            this.attackGroup = attackGroup;
            this.target = target;
        }

        public void Execute() => this.attackGroup.GroupTarget(this.target);
    }
}