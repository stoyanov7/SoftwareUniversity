namespace EventImplementation.Controller
{
    using System;
    using Models;
    using Models.Contracts;

    public class Engine
    {
        private readonly IDispatcher dispatcher;
        private readonly IHandler handler;

        public Engine()
        {
            this.dispatcher = new Dispatcher();
            this.handler = new Handler();
        }

        public void Run()
        {
            this.dispatcher.NameChange += this.handler.OnDispatcherNameChange;

            var name = string.Empty;
            while ((name = Console.ReadLine()) != "End")
            {
                this.dispatcher.Name = name;
            }
        }
    }
}