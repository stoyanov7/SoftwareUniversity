namespace AirConditionerTesterSystem.Core.Contracts
{
    public interface IDispatcher
    {
        string DispatchAction(IAction command);
    }
}