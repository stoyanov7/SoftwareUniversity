using System;
using System.Collections.Generic;
using System.Linq;

public class Phonebook
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(' ')
           .ToArray();

        var phonebook = new Dictionary<string, string>();
        

        while (!input[0].Equals("END"))
        {
            var command = input[0];
            var name = input[1];

            switch (command)
            {
                case "A":
                    var telephoneNumber = input[2];
                    phonebook[name] = telephoneNumber;
                    break;
                     
                case "S":
                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist.", name);
                    }
                    break;
                default:
                    break;
            }

            input = Console.ReadLine().Split(' ');
        }
    }
}