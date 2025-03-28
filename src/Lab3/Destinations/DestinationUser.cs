using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DestinationUser : IDestination
{
    private readonly User _user;

    public DestinationUser(User user)
    {
        _user = user;
    }

    public void SendMessage(Message message)
    {
        _user.AcceptMessage(message);
    }
}