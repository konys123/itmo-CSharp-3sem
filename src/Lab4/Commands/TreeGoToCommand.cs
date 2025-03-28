using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _path;

    public TreeGoToCommand(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        _path = path;
    }

    public void Execute()
    {
        _fileSystem.GoToDirectory(_path);
        Console.WriteLine($"вы теперь в {_path}");
    }
}