using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public interface IHandler
{
    public ICommand Handle(string command, IFileSystem fileSystem);

    public IHandler SetNext(IHandler nextHandler);

    public IHandler? NextHandler { get; set; }
}