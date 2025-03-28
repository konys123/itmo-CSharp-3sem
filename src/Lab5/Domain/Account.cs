namespace Itmo.ObjectOrientedProgramming.Lab5.Domain;

public class Account
{
    public string AccountNumber { get; }

    public string Pin { get; }

    public decimal Balance { get; private set; }

    public Account(string accountNumber, string pin, decimal balance)
    {
        AccountNumber = accountNumber;
        Pin = pin;
        Balance = balance;
    }

    public void Withdraw(decimal amount)
    {
        if (Balance < amount) throw new InvalidOperationException("Недостаточно средств");
        Balance -= amount;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Низя так :)");
        Balance += amount;
    }
}