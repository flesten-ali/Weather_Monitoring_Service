using Newtonsoft.Json;
using WeatherMonitor.ConfigData;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Bots;

public class RainBot : Bot
{
    public int HumidityThreshold { get; set; }

    protected override bool IsActivated(WeatherData weatherData)
    {
        return weatherData.Humidity > HumidityThreshold;
    }
}
