using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ConnectHandler : IHandler
{
    public ConnectHandler()
    {
        ModeHandler = new ConnectLocalModeHandler();
    }

    public ICommand Handle(string command, IFileSystem fileSystem)
    {
        string[] parts = command.Split(' ');

        if (parts.Length >= 3 && parts[2] == "-m" && parts[0] == "connect" && ModeHandler != null)
            return ModeHandler.Handle(command, fileSystem);

        if (NextHandler != null) return NextHandler.Handle(command, fileSystem);

        throw new InvalidOperationException("такой команды не существует");
    }

    public IHandler SetNext(IHandler nextHandler)
    {
        NextHandler = nextHandler;
        return nextHandler;
    }

    public IHandler? ModeHandler { get; set; }

    public IHandler? NextHandler { get; set; }
}