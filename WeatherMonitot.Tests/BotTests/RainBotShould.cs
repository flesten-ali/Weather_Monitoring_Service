using AutoFixture;
using Moq;
using WeatherMonitor.Bots;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Tests.BotTests;
public class RainBotShould : BotBaseTests
{
    private readonly RainBot _rainBot;
    private const int HumidityThreshold = 0;
    private const int HumidityActivateBot = HumidityThreshold + 1;
    private const int HumidityDeactivateBot = HumidityThreshold - 1;

    public RainBotShould()
    {
        Printer = new Mock<IPrint>();

        _rainBot = new RainBot(Printer.Object)
        {
            HumidityThreshold = HumidityThreshold,
            Enabled = true,
            Message = "RainBot"
        };
        Bot = _rainBot;
    }

    [Fact]
    public override void LogMessagesTwice_When_BotIsActivatedAndEnabled()
    {
        Bot.Update(CreateWeatherData(HumidityActivateBot));

        Printer.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
    }

    [Fact]
    public override void LogBotNameAndMessage_When_BotActivatedAndEnabled()
    {
        Bot.Update(CreateWeatherData(HumidityActivateBot));

        Printer.Verify(x => x.Log($"{Bot.GetType().Name} activated!"), Times.Once);
        Printer.Verify(x => x.Log(_rainBot.Message + Environment.NewLine), Times.Once);
    }

    [Theory]
    [InlineData(HumidityDeactivateBot, false)]
    [InlineData(HumidityDeactivateBot, true)]
    [InlineData(HumidityActivateBot, false)]
    public override void LogNothing_When_BotNotActivatedOrNotEnabled(int humidity, bool isEnabled)
    {
        _rainBot.Enabled = isEnabled;

        Bot.Update(CreateWeatherData(humidity));

        Printer.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void NotActivate_When_HumidityEqualsThreshold()
    {
        _rainBot.Update(CreateWeatherData(HumidityThreshold));

        Printer.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
    }

    public override WeatherData CreateWeatherData(int humidity)
    {
        var fixture = new Fixture();
        return fixture.Build<WeatherData>().With(x => x.Humidity, () => humidity).Create();
    }
}
