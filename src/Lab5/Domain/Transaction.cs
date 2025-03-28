namespace Itmo.ObjectOrientedProgramming.Lab5.Domain;

public class Transaction
{
    public int Id { get; }

    public string AccountNumber { get; }

    public string TransactionType { get; }

    public decimal Amount { get; }

    public DateTime TransactionDate { get; }

    public Transaction(int id, string accountNumber, string transactionType, decimal amount, DateTime date)
    {
        Id = id;
        AccountNumber = accountNumber;
        TransactionType = transactionType;
        Amount = amount;
        TransactionDate = date;
    }

    public Transaction(string accountNumber, string transactionType, decimal amount)
        : this(0, accountNumber, transactionType, amount, DateTime.UtcNow) { }
}