using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    public IEnumerable<Message> UnreadMessages { get; private set; } = new List<Message>();

    public IEnumerable<Message> ReadMessages { get; private set; } = new List<Message>();

    public void AcceptMessage(Message message)
    {
        var a = UnreadMessages.ToList();
        a.Add(message);
        UnreadMessages = a;
    }

    public void MarkMessageAsRead(Message message)
    {
        var a = UnreadMessages.ToList();
        var b = ReadMessages.ToList();

        if (a.Remove(message))
        {
            b.Add(message);
            UnreadMessages = a;
            ReadMessages = b;
            return;
        }

        throw new InvalidOperationException("сообщение уже прочитано");
    }
}