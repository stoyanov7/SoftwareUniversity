namespace AirConditionerTesterSystem.Core
{
    using System;
    using Contracts;
    using Loggers;

    public class Engine : IEngine
    {
        private readonly IDispatcher dispatcher;
        private readonly ILogger logger;

        public Engine(IDispatcher dispatcher, ILogger logger)
        {
            this.dispatcher = dispatcher;
            this.logger = logger;
        }

        public IAction Action { get; private set; }

        public void Run()
        {
            while (true)
            {
                var input = this.logger.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                input = input.Trim();
                var actionResult = string.Empty;

                try
                {
                    this.Action = new Action(input);
                    actionResult = this.dispatcher.DispatchAction(this.Action);
                    this.logger.WriteLine(actionResult);
                }
                catch (Exception e)
                {
                    this.logger.WriteLine(e.Message);
                }
            }
        }
    }
}