using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileRenameHandler : IHandler
{
    public ICommand Handle(string command, IFileSystem fileSystem)
    {
        string[] parts = command.Split(' ');

        if (parts.Length == 4 && parts[0] == "file" && parts[1] == "rename")
            return new FileRenameCommand(fileSystem, parts[2], parts[3]);

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