using AutoFixture;
using Moq;
using WeatherMonitor.Bots;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Tests.BotTests;

public class SunBotShould : BotBaseTests
{
    private readonly SunBot _sunBot;
    private const int TemperatureThreshold = 0;
    private const int TemperatureActivateBot = TemperatureThreshold + 1;
    private const int TemperatureDeactivateBot = TemperatureThreshold - 1;

    public SunBotShould()
    {
        Printer = new Mock<IPrint>();

        _sunBot = new SunBot(Printer.Object)
        {
            TemperatureThreshold = TemperatureThreshold,
            Enabled = true,
            Message = "SunBot"
        };
        Bot = _sunBot;
    }

    [Fact]
    public override void LogMessagesTwice_When_BotIsActivatedAndEnabled()
    {
        Bot.Update(CreateWeatherData(TemperatureActivateBot));

        Printer.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
    }

    [Fact]
    public override void LogBotNameAndMessage_When_BotActivatedAndEnabled()
    {
        Bot.Update(CreateWeatherData(TemperatureActivateBot));

        Printer.Verify(x => x.Log($"{Bot.GetType().Name} activated!"), Times.Once);
        Printer.Verify(x => x.Log(_sunBot.Message + Environment.NewLine), Times.Once);
    }

    [Theory]
    [InlineData(TemperatureDeactivateBot, false)]
    [InlineData(TemperatureDeactivateBot, true)]
    [InlineData(TemperatureActivateBot, false)]
    public override void LogNothing_When_BotNotActivatedOrNotEnabled(int temperature, bool isEnabled)
    {
        _sunBot.Enabled = isEnabled;

        Bot.Update(CreateWeatherData(temperature));

        Printer.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void NotActivate_When_TemperatureEqualsThreshold()
    {
        _sunBot.Update(CreateWeatherData(TemperatureThreshold));

        Printer.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
    }

    public override WeatherData CreateWeatherData(int temperature)
    {
        var fixture = new Fixture();
        return fixture.Build<WeatherData>().With(x => x.Temperature, () => temperature).Create();
    }
}
