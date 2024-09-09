using WeatherMonitor.Bots;
namespace WeatherMonitor.BotFactory;

public class SunBotFactory : BotFactory
{
    protected override Bot Create()
    {
        return new SunBot();
    }
}
