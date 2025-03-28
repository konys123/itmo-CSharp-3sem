using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private string Path { get; set; }

    public FileDeleteCommand(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        Path = path;
    }

    public void Execute()
    {
        _fileSystem.DeleteFile(Path);
        Console.WriteLine("Файл удален");
    }
}