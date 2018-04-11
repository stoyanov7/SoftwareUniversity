namespace EventImplementation.Models.Contracts
{
    public interface IHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}