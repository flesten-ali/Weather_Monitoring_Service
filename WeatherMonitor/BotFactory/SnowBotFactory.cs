using WeatherMonitor.Bots;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.BotFactory;

public class SnowBotFactory : BotFactory
{
    protected override Bot Create()
    {
        return new SnowBot(new Print());
    }
}
