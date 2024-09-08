namespace WeatherMonitor.BotFactory;
using WeatherMonitor.Bots;

public abstract class BotFactory
{
    protected abstract Bot Create();

    public Bot GetBot()
    {
        var instance = Create();
        return instance;
    }
}
