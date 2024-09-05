using WeatherMonitor.ConfigData;
using WeatherMonitor.WeatherManagement;
using WeatherMonitor.WeathersFactory;
namespace WeatherMonitor.Utilities;

public abstract class ApplicationSetUp
{

    public static void SetUpApplication(WeatherData weatherData)
    {
        JsonConfigHandler.LoadConfiguration();
        ConfigWeather(weatherData);
    }

    private static void ConfigWeather(WeatherData weatherData)
    {
        var weather = WeatherFactory.CreateWeather();
        ConfigBots(weather);
        weather.UpdateWeatherState(weatherData);
    }

    private static void ConfigBots(Weather weather)
    {
        var configurationData = ConfigurationData.ConfigurationDataInstance;
        weather.AddBot(configurationData.RainBot);
        weather.AddBot(configurationData.SunBot);
        weather.AddBot(configurationData.SnowBot);
    }
}
