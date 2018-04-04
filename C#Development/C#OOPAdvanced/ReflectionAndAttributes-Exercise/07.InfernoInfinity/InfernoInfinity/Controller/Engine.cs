namespace InfernoInfinity.Controller
{
    using System;
    using System.Linq;
    using Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine()
        {
            this.isRunning = true;
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var line = Console.ReadLine().Split(';').ToList();
                var command = line[0];

                switch (command)
                {
                    case "Create":
                        this.commandInterpreter.Create(line);
                        break;
                    case "Add":
                        this.commandInterpreter.Add(line);
                        break;
                    case "Remove":
                        this.commandInterpreter.Remove(line);
                        break;
                    case "Print":
                        this.commandInterpreter.Print(line);
                        break;
                    case "END":
                        this.isRunning = false;
                        break;
                }
            }
        }
    }
}