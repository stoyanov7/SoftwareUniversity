namespace _01.BankAccount
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bankAccount = new BankAccount();
            bankAccount.ID = 1;
            bankAccount.Balance = 15;

            Console.WriteLine($"Account {bankAccount.ID}, balance {bankAccount.Balance}");
        }
    }
}