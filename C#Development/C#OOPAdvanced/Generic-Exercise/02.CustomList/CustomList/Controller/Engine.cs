namespace CustomList.Controller
{
    using System;
    using System.Linq;

    public class Engine
    {
        private bool isRunning;
        private readonly ListManager manager;

        public Engine()
        {
            this.isRunning = true;
            this.manager = new ListManager();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToList();

                var command = input.First();
                input.RemoveAt(0);

                switch (command)
                {
                    case "Add":
                        this.manager.Add(input);
                        break;
                    case "Remove":
                        this.manager.Remove(input);
                        break;
                    case "Contains":
                        Console.WriteLine(this.manager.Contains(input));
                        break;
                    case "Swap":
                        this.manager.Swap(input);
                        break;
                    case "Greater":
                        Console.WriteLine(this.manager.Greater(input));
                        break;
                    case "Max":
                        Console.WriteLine(this.manager.Max());
                        break;
                    case "Min":
                        Console.WriteLine(this.manager.Min());
                        break;
                    case "Sort":
                        this.manager.Sort();
                        break;
                    case "Print":
                        Console.WriteLine(this.manager.Print());
                        break;
                    case "END":
                        this.isRunning = false;
                        break;
                }
            }
        }
    }
}