using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ConnectLocalModeHandler : IHandler
{
    public ICommand Handle(string command, IFileSystem fileSystem)
    {
        string[] parts = command.Split(' ');

        if (parts.Length == 4 && parts[2] == "-m" && parts[3] == "local") return new ConnectCommand(fileSystem, parts[1]);

        if (NextHandler != null) return NextHandler.Handle(command, fileSystem);

        throw new InvalidOperationException("такой команды не существует");
    }

    public IHandler SetNext(IHandler nextHandler)
    {
        NextHandler = nextHandler;
        return nextHandler;
    }

    public IHandler? NextHandler { get; set; }
}