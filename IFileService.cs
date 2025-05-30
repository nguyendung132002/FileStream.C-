public interface IFileService
{
    void WriteToFile(string filePath, string content);
    string? ReadFromFile(string filePath);
    bool FileExists(string filePath);
}