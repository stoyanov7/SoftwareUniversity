namespace _02.BankAccountMethods
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bankAccount = new BankAccount();
            bankAccount.ID = 1;
            bankAccount.Deposit(15);
            bankAccount.Withdraw(5);

            Console.WriteLine(bankAccount.ToString());
        }
    }
}