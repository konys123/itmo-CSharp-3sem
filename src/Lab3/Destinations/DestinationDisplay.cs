using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DestinationDisplay : IDestination
{
    private readonly IDisplayDriver _displayDriver;

    public DestinationDisplay(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void SendMessage(Message message)
    {
        _displayDriver.WriteText($"{message.Title}: {message.Body}");
    }
}