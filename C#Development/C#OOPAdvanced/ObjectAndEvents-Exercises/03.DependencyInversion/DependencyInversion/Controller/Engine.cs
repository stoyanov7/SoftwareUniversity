namespace DependencyInversion.Controller
{
    using System;
    using System.Linq;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly IPrimitiveCalculator primitiveCalculator;
        private bool isRunning;

        public Engine()
        {
            this.primitiveCalculator = new PrimitiveCalculator();
            this.isRunning = true;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                switch (input[0])
                {
                    case "mode":
                        this.primitiveCalculator.ChangeStrategy(char.Parse(input[1]));
                        break;
                    case "End":
                        this.isRunning = false;
                        break;
                    default:
                        Console.WriteLine(this.primitiveCalculator.PerformCalculation(int.Parse(input[0]), int.Parse(input[1])));
                        break;
                }
            }
        }
    }
}