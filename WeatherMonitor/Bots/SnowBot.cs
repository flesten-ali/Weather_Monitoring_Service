using Newtonsoft.Json;
using WeatherMonitor.ConfigData;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Bots;

public class SnowBot : Bot
{
    [JsonProperty("temperatureThreshold")]
    public int TemperatureThreshold { get; set; }

    protected override bool IsActivated(WeatherData weatherData)
    {
        return weatherData.Temperature < TemperatureThreshold;
    }
}
