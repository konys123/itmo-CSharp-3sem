namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private string? _currentPath;

    public void Connect(string address)
    {
        if (Directory.Exists(address))
            _currentPath = address;
        else
            throw new DirectoryNotFoundException("Директория не найдена.");
    }

    public void Disconnect()
    {
        _currentPath = null;
    }

    public void GoToDirectory(string path)
    {
        if (_currentPath == null) throw new NullReferenceException();

        string newPath = Path.IsPathRooted(path) ? path : Path.Combine(_currentPath, path);
        if (Directory.Exists(newPath)) _currentPath = newPath;
        else throw new DirectoryNotFoundException("Директория не найдена.");
    }

    public IEnumerable<string> ListDirectory(int depth)
    {
        if (_currentPath == null) throw new NullReferenceException();
        return GetEntries(_currentPath, depth);
    }

    public string ReadFile(string path)
    {
        if (_currentPath == null) throw new NullReferenceException();

        string fullPath = Path.IsPathRooted(path) ? path : Path.Combine(_currentPath, path);
        if (File.Exists(fullPath)) return File.ReadAllText(fullPath);

        throw new FileNotFoundException("Файл не найден.");
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        if (_currentPath == null) throw new NullReferenceException();

        string fullSourcePath = Path.IsPathRooted(sourcePath) ? sourcePath : Path.Combine(_currentPath, sourcePath);
        string fullDestinationPath = Path.IsPathRooted(destinationPath)
            ? destinationPath
            : Path.Combine(_currentPath, destinationPath);

        if (File.Exists(fullSourcePath))
            File.Move(fullSourcePath, Path.Combine(fullDestinationPath, Path.GetFileName(fullSourcePath)));
        else throw new FileNotFoundException("Файл не найден.");
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        if (_currentPath == null) throw new NullReferenceException();

        string fullSourcePath = Path.IsPathRooted(sourcePath) ? sourcePath : Path.Combine(_currentPath, sourcePath);
        string fullDestinationPath = Path.IsPathRooted(destinationPath)
            ? destinationPath
            : Path.Combine(_currentPath, destinationPath);

        if (File.Exists(fullSourcePath))
            File.Copy(fullSourcePath, Path.Combine(fullDestinationPath, Path.GetFileName(fullSourcePath)));
        else throw new FileNotFoundException("Файл не найден.");
    }

    public void DeleteFile(string path)
    {
        if (_currentPath == null) throw new NullReferenceException();

        string fullPath = Path.IsPathRooted(path) ? path : Path.Combine(_currentPath, path);
        if (File.Exists(fullPath))
            File.Delete(fullPath);
        else throw new FileNotFoundException("Файл не найден.");
    }

    public void RenameFile(string path, string newName)
    {
        if (string.IsNullOrEmpty(_currentPath)) throw new NullReferenceException();

        string fullPath = Path.IsPathRooted(path) ? path : Path.Combine(_currentPath, path);

        if (!File.Exists(fullPath)) throw new FileNotFoundException("Файл не найден.");

        string? directoryName = Path.GetDirectoryName(fullPath);
        if (string.IsNullOrEmpty(directoryName))
            throw new InvalidOperationException("Не удалось получить имя каталога из указанного пути.");

        string newFullPath = Path.Combine(directoryName, newName);
        if (File.Exists(newFullPath)) throw new IOException("Файл с таким именем уже существует.");

        File.Move(fullPath, newFullPath);
    }

    private IEnumerable<string> GetEntries(string path, int depth)
    {
        if (depth < 0) yield break;

        foreach (string dir in Directory.GetDirectories(path))
        {
            yield return dir;
            foreach (string dirr in GetEntries(dir, depth - 1)) yield return dirr;
        }

        foreach (string file in Directory.GetFiles(path))
            yield return file;
    }
}