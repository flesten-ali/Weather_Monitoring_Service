namespace WeatherMonitor.ConfigData;
 
    public interface IFileSystem
    {
        string ReadAllText(string path);
    }
 