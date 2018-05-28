namespace AirConditionerTesterSystem.Core.Contracts
{
    public interface IEngine
    {
        IAction Action { get; }

        void Run();
    }
}