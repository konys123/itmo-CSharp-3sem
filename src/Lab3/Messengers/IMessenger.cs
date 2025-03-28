namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger
{
    public string Name { get; set; }

    public void WriteMessage(string text);
}