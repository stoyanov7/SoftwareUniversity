using System;
using System.Collections.Generic;

public class FixEmails
{
    public static void Main(string[] args)
    {
        var nameAndEmail = new Dictionary<string, string>();

        while (true)
        {
            var name = Console.ReadLine();

            if (name.Equals("stop"))
            {
                break;
            }

            var email = Console.ReadLine();

            if (!nameAndEmail.ContainsKey(name) && !(email.EndsWith("uk") || email.EndsWith("us")))
            {
                nameAndEmail[name] = email;
            }
        }

        foreach (var element in nameAndEmail)
        {
            Console.WriteLine($"{element.Key} -> {element.Value}");
        }
    }
}
