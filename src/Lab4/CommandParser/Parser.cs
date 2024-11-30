using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser;

public class Parser
{
    private readonly IFileSystem _fileSystem;

    private readonly IHandler _rootHandler;

    public Parser(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;

        IHandler root = new ConnectHandler();
        _rootHandler = root;

        _rootHandler.SetNext(new DisconnectHandler())
            .SetNext(new FileCopyHandler())
            .SetNext(new FileDeleteHandler())
            .SetNext(new FileMoveHandler())
            .SetNext(new FileRenameHandler())
            .SetNext(new FileShowHandler())
            .SetNext(new TreeGoToHandler())
            .SetNext(new TreeListHandler());
    }

    public ICommand Parse(string input)
    {
        return _rootHandler.Handle(input, _fileSystem);
    }
}