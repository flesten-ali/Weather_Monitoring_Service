using WeatherMonitor.Utilities.Interfaces;

namespace WeatherMonitor.Utilities.WrapperClasses;

public class ConsoleWrapper : IConsoleWrapper
{
    public string ReadLine()
    {
        return Console.ReadLine()!;
    }
}
