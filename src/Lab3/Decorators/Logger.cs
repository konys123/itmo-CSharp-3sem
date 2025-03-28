namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Лог:{DateTime.Now} {message}");
    }
}