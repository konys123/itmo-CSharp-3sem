using Itmo.ObjectOrientedProgramming.Lab3.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class Tests3
{
    [Fact]
    public void MessageSaveInSatusUnread()
    {
        Message a = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lol")
            .SetImportanceLevel(2)
            .Build();

        var nyYa = new User();
        var adresat = new DestinationUser(nyYa);
        var topic = new Topic("dahz", adresat);
        topic.SendMessage(a);
        Assert.Single(nyYa.UnreadMessages);
    }

    [Fact]
    public void TryToChangeMessageStatus()
    {
        Message a = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lol")
            .SetImportanceLevel(2)
            .Build();
        var nyYa = new User();
        var adresat = new DestinationUser(nyYa);
        adresat.SendMessage(a);
        nyYa.MarkMessageAsRead(a);

        Assert.Empty(nyYa.UnreadMessages);
        Assert.Single(nyYa.ReadMessages);
    }

    [Fact]
    public void TryToChangeMessageStatusWhichRead()
    {
        Message a = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lol")
            .SetImportanceLevel(2)
            .Build();
        var nyYa = new User();
        var adresat = new DestinationUser(nyYa);
        adresat.SendMessage(a);
        nyYa.MarkMessageAsRead(a);

        Assert.Throws<InvalidOperationException>(() => nyYa.MarkMessageAsRead(a));
    }

    [Fact]
    public void MessageWithLowImportanceDontReachDestination()
    {
        Message a = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lol")
            .SetImportanceLevel(3)
            .Build();
        Message b = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lol")
            .SetImportanceLevel(1)
            .Build();
        var nyYa = new User();
        IDestination adresat = new DestinationUser(nyYa);
        adresat = new FilteringDestinationDecorator(adresat, 2);
        adresat.SendMessage(a);
        adresat.SendMessage(b);

        Assert.Single(nyYa.UnreadMessages);
    }

    [Fact]
    public void MessageLogging()
    {
        Message a = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lol")
            .SetImportanceLevel(2)
            .Build();
        Message b = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lolkek")
            .SetImportanceLevel(2)
            .Build();

        var user = new User();
        IDestination adresat = new DestinationUser(user);
        var mockLogger = new Mock<ILogger>();
        adresat = new LoggingDestinationDecorator(adresat, mockLogger.Object);
        adresat.SendMessage(a);
        adresat.SendMessage(a);
        adresat.SendMessage(b);

        mockLogger.Verify(logger => logger.Log(It.Is<string>(m => m == "lol" || m == "lolkek")), Times.Exactly(3));
    }

    [Fact]
    public void MessageWithLowImportanceDontReachDestination2()
    {
        Message a = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lol")
            .SetImportanceLevel(2)
            .Build();
        var nyYa = new User();
        IDestination adresat = new DestinationUser(nyYa);
        IDestination adresat2 = new DestinationUser(nyYa);
        adresat = new FilteringDestinationDecorator(adresat, 3);
        adresat2 = new FilteringDestinationDecorator(adresat2, 2);
        adresat.SendMessage(a);
        adresat2.SendMessage(a);

        Assert.Single(nyYa.UnreadMessages);
    }

    [Fact]
    public void MessengerWriteExpectedValue()
    {
        Message a = new MessageBuilder()
            .SetBody("aboba")
            .SetTitle("lol")
            .SetImportanceLevel(2)
            .Build();
        var mockMessenger = new Mock<IMessenger>();
        mockMessenger.SetupProperty(m => m.Name, "telegram");
        var adresat = new DestinationMessenger(mockMessenger.Object);
        adresat.SendMessage(a);

        mockMessenger.Verify(messenger => messenger.WriteMessage(It.Is<string>(m => m == "telegram: lol aboba")));
    }
}