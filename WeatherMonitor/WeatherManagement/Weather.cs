namespace WeatherMonitor.WeatherManagement;

public class Weather : WeatherBase
{
    public override void UpdateWeatherState(WeatherData data)
    {
        NotifyBots(data);
    }
}
