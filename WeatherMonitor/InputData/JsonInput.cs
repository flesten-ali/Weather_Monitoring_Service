using System.Text.Json;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.InputData;

public class JsonInput : IInputData
{
    public WeatherData? GetDate(string input)
    {
        WeatherData? weatherData = null;
        try
        {
            weatherData = JsonSerializer.Deserialize<WeatherData>(input);
        }
        catch
        {
            Print.Log("Invalid Json Format");
        }
        return weatherData;
    }

    public bool IsMatch(string input)
    {
        return input.StartsWith('{') && input.EndsWith('}');
    }
}
