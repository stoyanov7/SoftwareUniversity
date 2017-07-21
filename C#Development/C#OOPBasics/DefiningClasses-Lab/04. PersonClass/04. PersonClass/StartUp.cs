using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var lineTokens = input
                .Split(' ')
                .ToArray();
            var command = lineTokens[0];

            switch (command)
            {
                case "Create":
                    CreateAccount(int.Parse(lineTokens[1]), accounts);
                    break;
                case "Deposit":
                    Deposit(int.Parse(lineTokens[1]), double.Parse(lineTokens[2]), accounts);
                    break;
                case "Withdraw":
                    Withdraw(int.Parse(lineTokens[1]), double.Parse(lineTokens[2]), accounts);
                    break;
                case "Print":
                    Print(int.Parse(lineTokens[1]), accounts);
                    break;
            }
        }
    }

    private static void CreateAccount(int id, Dictionary<int, BankAccount> accounts)
    {
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
            return;
        }

        accounts[id] = new BankAccount(id);
    }

    private static void Deposit(int id, double amount, Dictionary<int, BankAccount> accounts)
    {
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        accounts[id].Deposit(amount);
    }

    private static void Withdraw(int id, double amount, Dictionary<int, BankAccount> accounts)
    {
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        if (accounts[id].Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }

        accounts[id].Withdraw(amount);
    }

    private static void Print(int id, Dictionary<int, BankAccount> accounts)
    {
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        Console.WriteLine(accounts[id].ToString());
    }
}