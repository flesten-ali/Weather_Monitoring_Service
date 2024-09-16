namespace WeatherMonitor.ConfigData;

public class FileSystem : IFileSystem
{
    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }
}
