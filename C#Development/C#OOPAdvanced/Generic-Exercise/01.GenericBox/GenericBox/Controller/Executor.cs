namespace GenericBox.Controller
{
    using System;
    using System.Linq;
    using Model;

    public static class Executor
    {
        public static void ExecuteBoxOfType(string type)
        {
            var n = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "string":
                    for (var i = 0; i < n; i++)
                    {
                        var element = new Box<string>(Console.ReadLine());
                        Console.WriteLine(element.Print());
                    }
                    break;
                case "integer":
                    for (var i = 0; i < n; i++)
                    {
                        var element = new Box<int>(int.Parse(Console.ReadLine()));
                        Console.WriteLine(element.Print());
                    }
                    break;
            }
            
        }

        public static void ExecuteSwapMethod(string type)
        {
            var n = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "string":
                    var stringBox = new Box<string>();

                    for (var i = 0; i < n; i++)
                    {
                        stringBox.Add(Console.ReadLine());
                    }

                    var stringSwapIndex = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

                    stringBox.SwapElement(stringSwapIndex[0], stringSwapIndex[1]);

                    Console.WriteLine(stringBox.ToString());
                    break;
                case "integer":
                    var box = new Box<int>();

                    for (var i = 0; i < n; i++)
                    {
                        box.Add(int.Parse(Console.ReadLine()));
                    }

                    var swapIndex = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

                    box.SwapElement(swapIndex[0], swapIndex[1]);

                    Console.WriteLine(box.ToString());
                    break;
            }
        }

        public static void ExecuteCountMethod(string type)
        {
            var n = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "string":
                    var box = new Box<string>();

                    for (var i = 0; i < n; i++)
                    {
                        box.Add(Console.ReadLine());
                    }

                    Console.WriteLine(box.Compare(box.Buffer, Console.ReadLine()));
                    break;
                case "double":
                    var doubleBox = new Box<double>();

                    for (var i = 0; i < n; i++)
                    {
                        doubleBox.Add(double.Parse(Console.ReadLine()));
                    }

                    Console.WriteLine(doubleBox.Compare(doubleBox.Buffer, double.Parse(Console.ReadLine())));
                    break;
            }
            
        }
    }
}