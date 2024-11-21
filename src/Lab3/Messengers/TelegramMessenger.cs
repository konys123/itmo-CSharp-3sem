namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class TelegramMessenger : IMessenger
{
    public string Name { get; } = "Telegram";

    public void WriteMessage(string text)
    {
        Console.WriteLine(text);
    }
}