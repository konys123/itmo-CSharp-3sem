namespace Itmo.ObjectOrientedProgramming.Lab5.Domain;

public interface ITransactionRepository
{
    public IEnumerable<Transaction> GetAllTransactions(string accountNumber);

    public void AddTransaction(Transaction transaction);
}