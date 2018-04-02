namespace Listy.Controller
{
    using System;
    using System.Linq;
    using Model;

    public class Engine
    {
        public void Run()
        {
            var listy = new ListyIterator<string>();

            try
            {
                var line = Console.ReadLine().Split().ToArray();

                while (line[0] != "END")
                {
                    var command = line[0];

                    switch (command)
                    {
                        case "Create":
                            if (line.Length == 1)
                            {
                                listy.Create();
                            }

                            listy.Create(line.Skip(1).ToArray());
                            break;
                        case "Move":
                            Console.WriteLine(listy.Move());
                            break;
                        case "Print":
                            Console.WriteLine(listy.Print());
                            break;
                        case "PrintAll":
                            Console.WriteLine(listy.PrintAll());
                            break;
                        case "HasNext":
                            Console.WriteLine(listy.HasNext());
                            break;
                    }

                    line = Console.ReadLine().Split().ToArray();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}