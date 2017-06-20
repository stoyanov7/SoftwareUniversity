namespace _02.OptimizedBankingSystem
{
    public class BankAccount
    {
        public string Name { get; set; }

        public string Bank { get; set; }

        public decimal Balance { get; set; }

        public BankAccount(string name, string bank, decimal balance)
        {
            this.Name = name;
            this.Bank = bank;
            this.Balance = balance;
        }
    }
}
