using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DestinationGroup : IDestination
{
    public DestinationGroup(IEnumerable<IDestination> destinations)
    {
        Destinations = destinations;
    }

    private IEnumerable<IDestination> Destinations { get; }

    public void SendMessage(Message message)
    {
        foreach (IDestination destination in Destinations)
        {
            destination.SendMessage(message);
        }
    }
}