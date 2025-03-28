using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class LoggingDestinationDecorator : IDestination
{
    private readonly IDestination _destination;
    private readonly ILogger _logger;

    public LoggingDestinationDecorator(IDestination destination, ILogger logger)
    {
        _destination = destination;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _logger.Log(message.Title);
        _destination.SendMessage(message);
    }
}