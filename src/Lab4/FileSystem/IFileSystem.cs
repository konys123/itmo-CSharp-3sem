namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    public void Connect(string address);

    public void Disconnect();

    public void GoToDirectory(string path);

    public IEnumerable<string> ListDirectory(int depth);

    public string ReadFile(string path);

    public void MoveFile(string sourcePath, string destinationPath);

    public void CopyFile(string sourcePath, string destinationPath);

    public void DeleteFile(string path);

    public void RenameFile(string path, string newName);
}