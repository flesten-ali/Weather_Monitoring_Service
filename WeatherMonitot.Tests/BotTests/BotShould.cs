using AutoFixture;
using Moq;
using Moq.Protected;
using WeatherMonitor.Bots;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Tests.BotTests;

public class BotShould
{
    private readonly Mock<IPrint> _printer;
    private readonly Mock<Bot> _bot;
    private readonly WeatherData _weatherData;

    public BotShould()
    {
        _printer = new Mock<IPrint>();
        _bot = new Mock<Bot>(_printer.Object) { CallBase = true};
        var fixture = new Fixture();
        _weatherData = fixture.Create<WeatherData>();
    }

    [Fact]
    public void CallPrinter_When_BotIsEnabledAndActivated()
    {
        _bot.Object.Enabled = true;
        _bot.Protected().Setup<bool>("IsActivated", _weatherData).Returns(true);

        _bot.Object.Update(_weatherData);

        _printer.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(false, true)]
    [InlineData(true, false)]
    public void NotCallPrinter_When_BotIsNotEnabledOrNotActivated(bool isEnables, bool isActivated)
    {
        _bot.Object.Enabled = isEnables;
        _bot.Protected().Setup<bool>("IsActivated", _weatherData).Returns(isActivated);

        _bot.Object.Update(_weatherData);

        _printer.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
    }
}
