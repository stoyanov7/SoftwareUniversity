using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OptimizedBankingSystem
{
    public class OptimizedBankingSystem
    {
        public static void Main(string[] args)
        {
            var bankAccounts = new List<BankAccount>();
            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                ReadBankSystem(bankAccounts, line);

                line = Console.ReadLine();
            }

            bankAccounts = bankAccounts
                .OrderByDescending(e => e.Balance)
                .ThenBy(e => e.Bank.Length)
                .ToList();

            foreach (var account in bankAccounts)
            {
                Console.WriteLine($"{account.Name} -> {account.Balance} ({account.Bank})");
            }
        }

        private static void ReadBankSystem(List<BankAccount> bankAccounts, string line)
        {
            var lineTokens = line
                                .Split(" | ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                .Select(e => e.Trim())
                                .ToArray();

            var bank = lineTokens[0];
            var name = lineTokens[1];
            var balance = decimal.Parse(lineTokens[2]);

            var bankAccount = new BankAccount(name, bank, balance);
            bankAccounts.Add(bankAccount);
        }
    }
}
