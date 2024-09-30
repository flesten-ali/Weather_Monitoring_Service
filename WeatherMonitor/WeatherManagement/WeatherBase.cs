using WeatherMonitor.Bots;
namespace WeatherMonitor.WeatherManagement;

public abstract class WeatherBase
{
    public readonly List<Bot> Bots = [];

    public void AddBot(Bot bot)
    {
        Bots.Add(bot);
    }

    public void RemoveBot(Bot bot)
    {
        Bots.Remove(bot);
    }

    protected void NotifyBots(WeatherData weatherData)
    {
        foreach (var bot in Bots)
        {
            bot.Update(weatherData);
        }
    }

    public abstract void UpdateWeatherState(WeatherData weatherData);
}
