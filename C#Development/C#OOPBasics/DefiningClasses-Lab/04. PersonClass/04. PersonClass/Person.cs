using System.Collections.Generic;
using System.Linq;

public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.Name = name;
        this.Age = age;
        this.Accounts = accounts;
    }

    private string Name { get; set; }

    private int Age { get; set; }

    private List<BankAccount> Accounts { get; set; }

    public double GetBalance() => this.Accounts.Sum(x => x.Balance);
}