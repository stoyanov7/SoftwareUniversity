namespace Heroes
{
    using Commands;
    using Loggers;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var combatLogger = new CombatLogger();
            var eventLogger = new EventLogger();

            combatLogger.SetSuccsessor(eventLogger);

            var group = new Group();
            group.AddMember(new Warrior("Torsten", 10, combatLogger));
            group.AddMember(new Warrior("Rolo", 15, combatLogger));

            var dragon = new Dragon("Transylvanian White", 200, 25, combatLogger);

            var executor = new CommandExecutor();

            var groupTarget = new GroupTargetCommand(group, dragon);
            var groupAttack = new GroupAttackCommand(group);
        }
    }
}
