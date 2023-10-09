using System.Text.Json;

namespace WorkingWithDirectoryAndFilesInCsharp;

public class DirectoryExample
{
    public void Run()
    {
        // ListDirectories();
        // ListDirectoriesWithPattern();
        // GetRootDirectory();
        // ListFiles();
        GetLogicalDrives();
    }

    private void ListDirectories()
    {
        var path = "c://Personal/Temp";
        var directoryInfo = new DirectoryInfo(path);
        string[] dirPaths = Directory.GetDirectories(path);
        DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
    }

    private void ListDirectoriesWithPattern()
    {
        var path = "C:\\Personal\\Temp\\folder ex";
        var pattern = "*folder_*";
        var directoryInfo = new DirectoryInfo(path);
        string[] dirPaths = Directory.GetDirectories(path, pattern, SearchOption.TopDirectoryOnly);
        DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories(pattern, SearchOption.AllDirectories);
        foreach (var dirInfo in directoryInfos)
        {
            Console.WriteLine(dirInfo.Name);
        }
    }

    private void GetRootDirectory()
    {
        var path = "C:\\Personal\\Temp\\folder ex";
        var root = Directory.GetDirectoryRoot(path);
        Console.WriteLine(root);
    }

    private void OtherDirectoryOperations()
    {
        var path = "path";
        var recursiveDeletion = true;
        Directory.Delete(path);
        Directory.Delete(path, recursiveDeletion);
    }

    private void ListFiles()
    {
        var path = "C:\\Personal\\Temp\\folder ex";
        var pattern = "*.txt";
        var files = Directory.GetFiles(path);
        Console.WriteLine("Without pattern: " + JsonSerializer.Serialize(files, new JsonSerializerOptions{WriteIndented = true}));
        files = Directory.GetFiles(path, pattern);
        Console.WriteLine("With pattern: " + JsonSerializer.Serialize(files, new JsonSerializerOptions{WriteIndented = true}));
    }

    private void Move()
    {
        Directory.Move("source", "destination");
    }

    private void GetLogicalDrives()
    {
        var drives = Directory.GetLogicalDrives();
        System.Console.WriteLine(JsonSerializer.Serialize(drives));
    }
}
