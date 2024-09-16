using WeatherMonitor.ConfigData;
using WeatherMonitor.Utilities.Interfaces;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities;

public class ApplicationSetUp : IApplicationSetUp
{
    private readonly IJsonConfigHandler _handler;

    public ApplicationSetUp(IJsonConfigHandler handler)
    {
        _handler = handler;
    }

    public void SetUpApplication(WeatherBase weatherBase, WeatherData weatherData)
    {
        _handler.LoadConfiguration();
        ConfigBots(weatherBase);
        ConfigWeather(weatherBase, weatherData);
    }

    private void ConfigBots(WeatherBase weather)
    {
        var configurationData = ConfigurationData.ConfigurationDataInstance;
        weather.AddBot(configurationData.RainBot);
        weather.AddBot(configurationData.SunBot);
        weather.AddBot(configurationData.SnowBot);
    }

    private void ConfigWeather(WeatherBase weatherBase, WeatherData weatherData)
    {
        weatherBase.UpdateWeatherState(weatherData);
    }
}
