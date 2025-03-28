using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private string Path { get; set; }

    public FileShowCommand(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        Path = path;
    }

    public void Execute()
    {
        Console.WriteLine(_fileSystem.ReadFile(Path));
    }
}