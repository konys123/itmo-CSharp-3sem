using Itmo.ObjectOrientedProgramming.Lab5.Domain;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure;

public class PostgresTransactionRepository : ITransactionRepository
{
    private readonly string _connectionString;

    public PostgresTransactionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Transaction> GetAllTransactions(string accountNumber)
    {
        var result = new List<Transaction>();
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();

        using var cmd = new NpgsqlCommand(
            """
            SELECT id, account_number, transaction_type, amount, transaction_date FROM transactions
            WHERE account_number = @accNum 
            ORDER BY transaction_date DESC
            """,
            conn);
        cmd.Parameters.AddWithValue("accNum", accountNumber);

        using NpgsqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Transaction(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDecimal(3),
                reader.GetDateTime(4)));
        }

        return result;
    }

    public void AddTransaction(Transaction transaction)
    {
        var result = new List<Transaction>();
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();

        using var cmd = new NpgsqlCommand(
            """
            INSERT INTO transactions (account_number, transaction_type, amount, transaction_date)
            VALUES (@accNum, @type, @amt, @dt)
            """,
            conn);

        cmd.Parameters.AddWithValue("accNum", transaction.AccountNumber);
        cmd.Parameters.AddWithValue("type", transaction.TransactionType);
        cmd.Parameters.AddWithValue("amt", transaction.Amount);
        cmd.Parameters.AddWithValue("dt", transaction.TransactionDate);

        cmd.ExecuteNonQuery();
    }
}