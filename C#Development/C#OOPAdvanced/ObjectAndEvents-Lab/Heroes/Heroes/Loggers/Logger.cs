namespace Heroes.Loggers
{
    using Enums;
    using Models.Contracts;

    public abstract class Logger : IHandler
    {
        private IHandler successor;

        public void SetSuccsessor(IHandler newSuccessor)
        {
            this.successor = newSuccessor;
        }

        protected void PassToSuccess(LogType type, string message)
        {
            this.successor?.Handle(type, message);
        }

        public abstract void Handle(LogType type, string message);
    }
}