using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Bots;

public class RainBot : Bot
{
    public RainBot(IPrint print) : base(print)
    {
    }

    public int HumidityThreshold { get; set; }

    protected override bool IsActivated(WeatherData weatherData)
    {
        return weatherData.Humidity > HumidityThreshold;
    }
}
