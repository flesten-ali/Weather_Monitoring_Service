using WeatherMonitor.Bots;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.BotFactory;

public class SunBotFactory : BotFactory
{
    protected override Bot Create()
    {
        return new SunBot(new Print());
    }
}
