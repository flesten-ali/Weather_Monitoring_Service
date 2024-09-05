namespace WeatherMonitor.WeatherManagement;

public class Weather : WeatherBase
{
    public void UpdateWeatherState(WeatherData data)
    {
        NotifyBots(data);
    }
}
