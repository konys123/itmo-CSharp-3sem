using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class FilteringDestinationDecorator : IDestination
{
    private readonly IDestination _destination;
    private readonly ImportanceLevel _minImportanceLevel;

    public FilteringDestinationDecorator(IDestination destination, int minImportanceLevel)
    {
        _destination = destination;
        _minImportanceLevel = (ImportanceLevel)minImportanceLevel;
    }

    public void SendMessage(Message message)
    {
        if (message.ImportanceLevel >= _minImportanceLevel)
        {
            _destination.SendMessage(message);
        }
    }
}