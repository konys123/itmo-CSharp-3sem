using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Moq;
using Xunit;

namespace Lab4.Tests;

public class TestsLab4
{
    [Fact]
    public void TryParseConnectCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("connect Cocatfizika:\' -m local");

        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void TryParseDisconnectCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("disconnect");

        Assert.IsType<DisconnectCommand>(command);
    }

    [Fact]
    public void TryParseCopyCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("file copy C: D:");

        Assert.IsType<FileCopyCommand>(command);
    }

    [Fact]
    public void TryParseDeleteCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("file delete C:\'");

        Assert.IsType<FileDeleteCommand>(command);
    }

    [Fact]
    public void TryParseMoveCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("file move C:\'xz D:");

        Assert.IsType<FileMoveCommand>(command);
    }

    [Fact]
    public void TryParseRenameCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("file rename C:\'file fizikaXyita");

        Assert.IsType<FileRenameCommand>(command);
    }

    [Fact]
    public void TryParseShowCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("file show C:\'xz -m console");

        Assert.IsType<FileShowCommand>(command);
    }

    [Fact]
    public void TryParseGoToCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("tree goto C:\'acho");

        Assert.IsType<TreeGoToCommand>(command);
    }

    [Fact]
    public void TryParseTreeListCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("tree list -d 1");

        Assert.IsType<TreeListCommand>(command);
    }

    [Fact]
    public void ConnectCommand()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var parser = new Parser(mockFileSystem.Object);
        ICommand command = parser.Parse("connect Cocatfizika:\' -m local");
        command.Execute();

        mockFileSystem.Verify(
            system =>
                system.Connect(It.Is<string>(adress => adress == "Cocatfizika:\'")),
            Times.Once());
    }
}