using WeatherMonitor.Bots;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.BotFactory;

public class RainBotFactory : BotFactory
{
    protected override Bot Create()
    {
       return new RainBot(new Print());
    }
}
