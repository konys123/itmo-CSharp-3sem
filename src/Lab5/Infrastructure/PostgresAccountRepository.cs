using Itmo.ObjectOrientedProgramming.Lab5.Domain;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure;

public class PostgresAccountRepository : IAccountRepository
{
    private readonly string _connectionString;

    public PostgresAccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Account? GetByNumber(string accountNumber)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        using var cmd = new NpgsqlCommand(
            """
            SELECT account_number, pin, balance FROM accounts
            WHERE account_number = @accNum
            """,
            conn);
        cmd.Parameters.AddWithValue("accNum", accountNumber);

        using NpgsqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Account(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetDecimal(2));
        }

        return null;
    }

    public void Save(Account account)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        using var cmd = new NpgsqlCommand(
            """
            UPDATE accounts SET balance = @bal
            WHERE account_number = @accNum
            """,
            conn);

        cmd.Parameters.AddWithValue("accNum", account.AccountNumber);
        cmd.Parameters.AddWithValue("bal", account.Balance);

        cmd.ExecuteNonQuery();
    }

    public void Create(Account account)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        using var cmd = new NpgsqlCommand(
            """
            INSERT INTO accounts (account_number, pin, balance)
            VALUES (@accNum, @pin, @bal)
            """,
            conn);

        cmd.Parameters.AddWithValue("accNum", account.AccountNumber);
        cmd.Parameters.AddWithValue("bal", account.Balance);
        cmd.Parameters.AddWithValue("pin", account.Pin);

        cmd.ExecuteNonQuery();
    }
}