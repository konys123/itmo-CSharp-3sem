namespace Itmo.ObjectOrientedProgramming.Lab5.Domain;

public class AccountService
{
    private readonly IAccountRepository _accountRepo;
    private readonly ITransactionRepository _transactionRepo;

    public AccountService(IAccountRepository accountRepo, ITransactionRepository transactionRepo)
    {
        _accountRepo = accountRepo;
        _transactionRepo = transactionRepo;
    }

    public void Withdraw(string accountNumber, decimal amount)
    {
        Account acc = _accountRepo.GetByNumber(accountNumber) ??
                      throw new InvalidOperationException("Account not found");
        acc.Withdraw(amount);
        _accountRepo.Save(acc);
        _transactionRepo.AddTransaction(new Transaction(accountNumber, "withdraw", amount));
    }

    public void Deposit(string accountNumber, decimal amount)
    {
        Account acc = _accountRepo.GetByNumber(accountNumber) ??
                      throw new InvalidOperationException("Account not found");
        acc.Deposit(amount);
        _accountRepo.Save(acc);
        _transactionRepo.AddTransaction(new Transaction(accountNumber, "deposit", amount));
    }

    public decimal GetBalance(string accountNumber)
    {
        Account acc = _accountRepo.GetByNumber(accountNumber) ??
                      throw new InvalidOperationException("Account not found");
        return acc.Balance;
    }

    public IEnumerable<Transaction> GetHistory(string accountNumber)
    {
        return _transactionRepo.GetAllTransactions(accountNumber);
    }

    public void CreateAccount(string accountNumber, string pin)
    {
        var account = new Account(accountNumber, pin, 0);
        _accountRepo.Create(account);
    }

    public bool Authenticate(string accountNumber, string pin)
    {
        Account? acc = _accountRepo.GetByNumber(accountNumber);
        if (acc == null) return false;
        return acc.Pin == pin;
    }
}