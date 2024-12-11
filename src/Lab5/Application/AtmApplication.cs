using Itmo.ObjectOrientedProgramming.Lab5.Domain;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application;

public class AtmApplication
{
    private readonly AccountService _accountService;

    public AtmApplication(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void CreateAccount(string accountNumber, string pin)
    {
        _accountService.CreateAccount(accountNumber, pin);
    }

    public void ShowBalance(string accountNumber)
    {
        decimal balance = _accountService.GetBalance(accountNumber);
        Console.WriteLine($"Баланс: {balance}");
    }

    public void Withdraw(string accountNumber, decimal amount)
    {
        _accountService.Withdraw(accountNumber, amount);
        Console.WriteLine("Снятие выполнено успешно.");
    }

    public void Deposit(string accountNumber, decimal amount)
    {
        _accountService.Deposit(accountNumber, amount);
        Console.WriteLine("Пополнение выполнено успешно.");
    }

    public void ShowHistory(string accountNumber)
    {
        IEnumerable<Transaction> history = _accountService.GetHistory(accountNumber);
        foreach (Transaction t in history)
        {
            Console.WriteLine($"{t.TransactionDate}: {t.TransactionType} {t.Amount}");
        }
    }

    public bool Authorization(string accountNumber, string pin)
    {
        return _accountService.Authenticate(accountNumber, pin);
    }
}