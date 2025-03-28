using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DestinationMessenger : IDestination
{
    private readonly IMessenger _messenger;

    public DestinationMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        _messenger.WriteMessage($"{_messenger.Name}: {message.Title} {message.Body}");
    }
}