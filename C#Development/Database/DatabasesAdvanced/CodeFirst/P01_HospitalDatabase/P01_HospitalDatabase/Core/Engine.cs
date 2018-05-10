namespace P01_HospitalDatabase.Core
{
    using System;

    public class Engine
    {
        private bool isRunning;
        private readonly CommandInterpreter commandInterpreter;

        public Engine()
        {
            this.isRunning = true;
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            var command = Console.ReadLine();

            while (this.isRunning)
            {
                switch (command)
                {
                    case "GetAllPatients":
                        this.commandInterpreter.GetAllPatients();
                        break;
                    case "GetAllDoctors":
                        this.commandInterpreter.GetAllDoctors();
                        break;
                    case "Exit":
                        this.isRunning = false;
                        break;
                }
            }
        }
    }
}