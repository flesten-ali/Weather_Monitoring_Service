using WeatherMonitor.ConfigData;
using WeatherMonitor.Bots;
namespace WeatherMonitor.WeatherManagement;

public abstract class WeatherBase
{
    private readonly List<Bot> _bots = [];
    public void AddBot(Bot bot)
    {
        _bots.Add(bot);
    }
    public void RemoveBot(Bot bot)
    {
        _bots.Remove(bot);
    }
    protected void NotifyBots(WeatherData weatherData)
    {
        foreach (var bot in _bots)
        {
            bot.Update(weatherData);
        }
    }
}
