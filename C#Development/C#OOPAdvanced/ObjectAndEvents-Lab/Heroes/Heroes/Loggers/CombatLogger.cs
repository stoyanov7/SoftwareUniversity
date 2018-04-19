namespace Heroes.Loggers
{
    using System;
    using Enums;

    public class CombatLogger : Logger
    {
        public override void Handle(LogType type, string message)
        {
            switch (type)
            {
                case LogType.ATTACK:
                    Console.WriteLine(type.ToString() + ": " + message);
                    break;
                case LogType.MAGIC:
                    Console.WriteLine(type.ToString() + ": " + message);
                    break;
            }

            this.PassToSuccess(type, message);
        }
    }
}