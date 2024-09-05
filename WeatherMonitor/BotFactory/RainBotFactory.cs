using WeatherMonitor.Bots;
namespace WeatherMonitor.BotFactory;

public class RainBotFactory : BotFactory
{
    protected override Bot Create()
    {
       return new RainBot();
    }
}
