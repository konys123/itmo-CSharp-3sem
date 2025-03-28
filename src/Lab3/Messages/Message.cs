namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    public Message(string title, string body, int importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = (ImportanceLevel)importanceLevel;
    }

    public string Title { get; private set; }

    public string Body { get; private set; }

    public ImportanceLevel ImportanceLevel { get; private set; }
}