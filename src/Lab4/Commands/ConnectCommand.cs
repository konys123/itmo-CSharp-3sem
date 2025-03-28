using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly IFileSystem _fileSystem;
    private readonly string _address;

    public ConnectCommand(IFileSystem fileSystem, string address)
    {
        _fileSystem = fileSystem;
        _address = address;
    }

    public void Execute()
    {
        _fileSystem.Connect(_address);
        Console.WriteLine($"Подключено к {_address}");
    }
}