 namespace WeatherMonitor.PrintConfig;

public class Print : IPrint
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
