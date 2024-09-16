using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Bots;

public class SnowBot : Bot
{
    public SnowBot(IPrint print) : base(print)
    {
    }

    public int TemperatureThreshold { get; set; }

    protected override bool IsActivated(WeatherData weatherData)
    {
        return weatherData.Temperature < TemperatureThreshold;
    }
}
