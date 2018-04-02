namespace CustomStack.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class Engine
    {
        private bool isRunning;
        private readonly CustomStack<string> customStack;

        public Engine()
        {
            this.isRunning = true;
            this.customStack = new CustomStack<string>();
        }

        public void Run()
        {
            try
            {
                while (this.isRunning)
                {
                    var tokens = Console.ReadLine()
                        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var command = tokens[0];

                    switch (command)
                    {
                        case "Push":
                            this.customStack.Push(tokens.Skip(1).ToArray());
                            break;
                        case "Pop":
                            this.customStack.Pop();
                            break;
                        case "END":
                            this.isRunning = false;
                            Print(this.customStack);
                            Print(this.customStack);
                            break;
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Print(IEnumerable<string> customStack)
        {
            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}