namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageBuilder
{
    private string? Title { get; set; }

    private string? Body { get; set; }

    private int ImportanceLevel { get; set; }

    public MessageBuilder SetTitle(string title)
    {
        Title = title;
        return this;
    }

    public MessageBuilder SetBody(string body)
    {
        Body = body;
        return this;
    }

    public MessageBuilder SetImportanceLevel(int implev)
    {
        ImportanceLevel = implev;
        return this;
    }

    public Message Build()
    {
        if (Title == null || Body == null || ImportanceLevel <= 0 || ImportanceLevel > 3)
            throw new NullReferenceException("нельзя собрать сообщение без всех аргументов");
        return new Message(Title, Body, ImportanceLevel);
    }
}