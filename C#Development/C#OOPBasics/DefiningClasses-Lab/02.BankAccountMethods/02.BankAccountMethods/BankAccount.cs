namespace _02.BankAccountMethods
{
    public class BankAccount
    {
        private int id;
        private double balance;

        public int ID
        {
            get => this.id;
            set => this.id = value;
        }

        public void Deposit(double amount) => this.balance += amount;

        public void Withdraw(double amount) => this.balance -= amount;

        public override string ToString() => $"Account ID{this.id}, balance {this.balance:F2}";
    }
}