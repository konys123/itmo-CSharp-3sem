using Itmo.ObjectOrientedProgramming.Lab5.Application;
using Itmo.ObjectOrientedProgramming.Lab5.Domain;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab5.UI;

namespace Itmo.ObjectOrientedProgramming.Lab5;

public class Program
{
    public static void Main(string[] args)
    {
        string adminPassword = "1234";

        string connectionString = "Host=localhost;Port=5432;Database=lab5;Username=postgres;Password=1234588asd";

        var accountRepo = new PostgresAccountRepository(connectionString);
        var txRepo = new PostgresTransactionRepository(connectionString);
        var accountService = new AccountService(accountRepo, txRepo);
        var app = new AtmApplication(accountService);

        var runner = new ConsoleRunner(app, adminPassword);
        runner.Run();
    }
}