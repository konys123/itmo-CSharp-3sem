using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private string Path { get; set; }

    private string Name { get; set; }

    public FileRenameCommand(IFileSystem fileSystem, string path, string name)
    {
        _fileSystem = fileSystem;
        Path = path;
        Name = name;
    }

    public void Execute()
    {
        _fileSystem.RenameFile(Path, Name);
        Console.WriteLine("Файл переименован");
    }
}