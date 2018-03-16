namespace Minedraft.Controller
{
    using System;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private bool isRunning;
        private readonly DraftManager builder;

        public Engine()
        {
            this.builder = new DraftManager();
            this.isRunning = true;
        }

        public string Run()
        {
            var sb = new StringBuilder();

            while (this.isRunning)
            {
                var cmdArgs = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                var command = cmdArgs[0];
                cmdArgs.RemoveAt(0);

                switch (command)
                {
                    case "RegisterHarvester":
                        sb.AppendLine(this.builder.RegisterHarvester(cmdArgs));
                        break;
                    case "RegisterProvider":
                        sb.AppendLine(this.builder.RegisterProvider(cmdArgs));
                        break;
                    case "Day":
                        sb.AppendLine(this.builder.Day());
                        break;
                    case "Mode":
                        sb.AppendLine(this.builder.Mode(cmdArgs));
                        break;
                    case "Check":
                        sb.AppendLine(this.builder.Check(cmdArgs));
                        break;
                    case "Shutdown":
                        sb.AppendLine(this.builder.ShutDown());
                        this.isRunning = false;
                        break;
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}