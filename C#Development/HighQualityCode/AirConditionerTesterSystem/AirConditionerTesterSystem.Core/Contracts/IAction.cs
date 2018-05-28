namespace AirConditionerTesterSystem.Core.Contracts
{
    public interface IAction
    {
        string Name { get; }

        string[] Parameters { get; }
    }
}