namespace Itmo.ObjectOrientedProgramming.Lab5.Domain;

public interface IAccountRepository
{
    public Account? GetByNumber(string accountNumber);

    public void Save(Account account);

    public void Create(Account account);
}