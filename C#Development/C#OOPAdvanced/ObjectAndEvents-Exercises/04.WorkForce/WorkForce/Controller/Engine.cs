namespace WorkForce.Controller
{
    using System;

    public class Engine
    {
        private bool isRunnig;
        private readonly CommandInterpreter commandInterpreter;

        public Engine()
        {
            this.isRunnig = true;
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            while (this.isRunnig)
            {
                var input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "Job":
                        this.commandInterpreter.CreateJob(input);
                        break;
                    case "StandardEmployee":
                        this.commandInterpreter.CreateStandartEmployee(input);
                        break;
                    case "PartTimeEmployee":
                        this.commandInterpreter.CreatePartTimeEmployee(input);
                        break;
                    case "Pass":
                        this.commandInterpreter.Pass();
                        break;
                    case "Status":
                        this.commandInterpreter.Status();
                        break;
                    case "End":
                        this.isRunnig = false;
                        break;
                }
            }
        }
    }
}