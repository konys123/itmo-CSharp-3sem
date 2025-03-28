using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    private string SourcePath { get; set; }

    private string DestinationPath { get; set; }

    public FileCopyCommand(IFileSystem fileSystem, string destinationPath, string sourcePath)
    {
        _fileSystem = fileSystem;
        DestinationPath = destinationPath;
        SourcePath = sourcePath;
    }

    public void Execute()
    {
        _fileSystem.CopyFile(SourcePath, DestinationPath);
        Console.WriteLine("Файл скопирован");
    }
}