using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class TreeGoToHandler : IHandler
{
    public bool Handle(string command)
    {
        string[] parts = command.Split(' ');

        if (parts.Length == 3 && parts[0] == "tree" && parts[1] == "goto") return true;

        return false;
    }

    public ICommand Handle(string command, IFileSystem fileSystem)
    {
        string[] parts = command.Split(' ');

        if (parts.Length == 3 && parts[0] == "tree" && parts[1] == "goto")
            return new TreeGoToCommand(fileSystem, parts[2]);

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