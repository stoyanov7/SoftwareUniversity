namespace BookShop.Core
{
    using System;
    using Contracts;
    using Data;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly CommandInterpreter commandInterpreter;
        private readonly BookShopContext context;

        public Engine()
        {
            this.isRunning = true;
            this.commandInterpreter = new CommandInterpreter();
            this.context = new BookShopContext();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var input = Console.ReadLine()
                    .ToLower()
                    .Split();

                if (input[0].Equals("exit"))
                {
                    this.isRunning = false;
                    break;
                }

                using (this.context)
                {
                    var command = this.commandInterpreter.InterpretCommand(input);
                    var result = command.Execute();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
