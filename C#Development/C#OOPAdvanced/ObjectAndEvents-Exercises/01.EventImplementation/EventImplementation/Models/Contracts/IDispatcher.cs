namespace EventImplementation.Models.Contracts
{
    public interface IDispatcher
    {
        string Name { get; set; }

        event NameChangeEventHandler NameChange;
    }
}