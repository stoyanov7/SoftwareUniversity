namespace Avatar.Controller
{
    using System;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private readonly NationsBuilder builder;
        private bool isRunning;
        
        public Engine()
        {
            this.isRunning = true;
            this.builder = new NationsBuilder();
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
                    case "Bender":
                        this.builder.AssignBender(cmdArgs);
                        break;
                    case "Monument":
                        this.builder.AssignMonument(cmdArgs);
                        break;
                    case "Status":
                        sb.AppendLine(this.builder.GetStatus(cmdArgs[0]));
                        break;
                    case "War":
                        this.builder.IssueWar(cmdArgs[0]);
                        break;
                    case "Quit":
                        sb.AppendLine(this.builder.GetWarsRecord());
                        this.isRunning = false;
                        break;
                }
            }

            return sb
                .ToString()
                .TrimEnd();
        }
    }
}