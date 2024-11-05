using System.Text.Json;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.InputData;

public class JsonInput : IInputData
{
    private readonly IPrint _printer;

    public JsonInput(IPrint print)
    {
        _printer = print;

    }

    public WeatherData? ParseData(string input)
    {
        WeatherData? weatherData = null;
        try
        {
            weatherData = JsonSerializer.Deserialize<WeatherData>(input);
        }
        catch 
        {
            throw new FormatException("Invalid Json Format");
        }
        return weatherData;
    }

    public bool IsMatch(string input)
    {
        return input.StartsWith('{') && input.EndsWith('}');
    }
}
