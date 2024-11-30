using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileShowHandler : IHandler
{
    public FileShowHandler()
    {
        ModeHandler = new FileShowConsoleModeHandler();
    }

    public ICommand Handle(string command, IFileSystem fileSystem)
    {
        string[] parts = command.Split(' ');

        if (parts.Length >= 4 && parts[3] == "-m" && parts[0] == "file" && parts[1] == "show" && ModeHandler != null)
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