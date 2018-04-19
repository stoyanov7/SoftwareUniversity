namespace Heroes.Models.Contracts
{
    using Enums;

    public interface IHandler
    {
        void Handle(LogType type, string message);

        void SetSuccsessor(IHandler newSuccessor);
    }
}