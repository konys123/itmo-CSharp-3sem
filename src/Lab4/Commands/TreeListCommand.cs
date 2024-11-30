using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private int Depth { get; set; }

    public TreeListCommand(IFileSystem fileSystem, int depth)
    {
        _fileSystem = fileSystem;
        Depth = depth;
    }

    public void Execute()
    {
        IEnumerable<string> a = _fileSystem.ListDirectory(Depth);
        foreach (string b in a) Console.WriteLine(b);
    }
}