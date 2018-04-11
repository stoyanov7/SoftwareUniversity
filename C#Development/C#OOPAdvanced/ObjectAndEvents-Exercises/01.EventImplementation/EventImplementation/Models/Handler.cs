namespace EventImplementation.Models
{
    using System;
    using Contracts;

    public class Handler : IHandler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}