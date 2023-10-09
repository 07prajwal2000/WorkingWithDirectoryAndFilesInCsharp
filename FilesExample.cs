using System.IO;
using System.Text;

namespace WorkingWithDirectoryAndFilesInCsharp;

public class FilesExample
{
    public void Run()
    {
        // CreateFile_FileClass();
        // CreateFile_FileInfoClass();
        // CreateFile_FileStreamClass();
        // ReadFile_FileClass();
        // OtherFileOperations();
    }
    
    private void CreateFile_FileClass()
    {
        using var fs = File.Create("temp.txt");
    }
    
    private void CreateFile_FileStreamClass()
    {
        using var fs = new FileStream("temp.txt", FileMode.Create);
    }
    
    private void CreateFile_FileInfoClass()
    {
        var fileInfo = new FileInfo("temp.txt");
        using var fs = fileInfo.Create();
    }
    
    private void ReadFile_FileClass()
    {
        var text = File.ReadAllText("temp.txt");
        string[] lines = File.ReadAllLines("temp.txt");
        byte[] fileAsBytes = File.ReadAllBytes("temp.txt");
    }
    
    private void ReadFile_FileStreamClass()
    {
        using var fs = new FileStream("temp.txt", FileMode.Open);
        var buffer = new byte[1024];
        var totalRead = fs.Read(buffer, 0, buffer.Length);
    }
    
    private void ReadFile_FileInfoClass()
    {
        var fileInfo = new FileInfo("temp.txt");
        using var fs = fileInfo.OpenRead();
        var buffer = new byte[1024];
        var totalRead = fs.Read(buffer, 0, buffer.Length);
    }
    
    private void ReadFile_StreamReaderClass()
    {
        using var fs = new StreamReader("temp.txt");
        var charBuffer = new char[1024];
        var totalRead = fs.Read(charBuffer); // Reads the string
        var fileContents = new string(charBuffer);
    }
    
    private void WriteFile_FileClass()
    {
        File.WriteAllText("temp.txt", "hello world");
        File.AppendAllText("temp.txt", "hello world appended");

        File.WriteAllBytes("temp.txt", Encoding.UTF8.GetBytes("Hello world from bytes"));

        var lines = new[] {"Line 1", "Line 2"};
        File.WriteAllLines("temp.txt", lines);

        var linesToAppend = new[] {"Line 1 append", "Line 2 append"};
        File.AppendAllLines("temp.txt", linesToAppend);
    }
    
    private void WriteFile_FileStreamClass()
    {
        using var fs = new FileStream("temp.txt", FileMode.Open);
        var buffer = Encoding.UTF8.GetBytes("Hello world");
        fs.Write(buffer);
    }
    
    private void WriteFile_FileInfoClass()
    {
        var fileInfo = new FileInfo("temp.txt");
        using var fs = fileInfo.OpenRead();
        var buffer = Encoding.UTF8.GetBytes("Hello world");
        fs.Write(buffer);
    }
    
    private void WriteFile_StreamReaderClass()
    {
        using var fs = new StreamWriter("temp.txt");
        var strContents = "Hello world";
        fs.Write(strContents); // anything which supports ToString() method
        fs.WriteLine(strContents); // same here
    }

    private void OtherFileOperations()
    {
        var fileExists = File.Exists("temp.txt");
        File.Move("temp.txt", "folder/temp.txt");
        File.Copy("temp.txt", "folder/temp.txt");
        File.Delete("folder/temp.txt");

        var file = new FileInfo("temp.txt");
        fileExists = file.Exists;
        file.MoveTo("destination/temp.txt");
        file.Delete();
        file.CopyTo("destination/temp.txt");
    }
}
