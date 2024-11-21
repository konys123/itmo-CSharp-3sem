namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class VkMessenger : IMessenger
{
    public string Name { get; } = "VK";

    public void WriteMessage(string text)
    {
        Console.WriteLine(text);
    }
}