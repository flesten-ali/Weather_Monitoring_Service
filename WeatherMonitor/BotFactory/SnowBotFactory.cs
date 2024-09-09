using WeatherMonitor.Bots;
namespace WeatherMonitor.BotFactory;

public class SnowBotFactory : BotFactory
{
    protected override Bot Create()
    {
        return new SnowBot();
    }
}
