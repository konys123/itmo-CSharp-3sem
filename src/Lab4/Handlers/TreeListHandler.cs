using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class TreeListHandler : IHandler
{
    public TreeListHandler()
    {
        ModeHandler = new TreeListDepthHandler();
    }

    public ICommand Handle(string command, IFileSystem fileSystem)
    {
        string[] parts = command.Split(' ');

        if (parts.Length >= 3 && parts[2] == "-d" && parts[0] == "tree" && parts[1] == "list" && ModeHandler != null)
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