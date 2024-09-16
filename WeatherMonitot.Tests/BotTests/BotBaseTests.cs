using Moq;
using WeatherMonitor.Bots;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Tests.BotTests;

public abstract class BotBaseTests
{
    protected Mock<IPrint> Printer;
    protected Bot Bot;
    public abstract void LogMessagesTwice_When_BotIsActivatedAndEnabled();
    public abstract void LogBotNameAndMessage_When_BotActivatedAndEnabled();
    public abstract void LogNothing_When_BotNotActivatedOrNotEnabled(int criteria, bool isEnabled);
    public abstract WeatherData CreateWeatherData(int criteria);
}
