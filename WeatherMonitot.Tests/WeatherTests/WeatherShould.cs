using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using WeatherMonitor.Bots;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Tests.WeatherTests;

public class WeatherShould
{
    private readonly Mock<Weather> _weather;
    private readonly WeatherData _weatherData;

    public WeatherShould()
    {
        _weather = new Mock<Weather>() { CallBase = true }; ;

        var fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization());
        _weatherData = fixture.Create<WeatherData>();
    }
    [Fact]

    public void CallUpdateOnAllBots()
    {
        var printer = new Mock<IPrint>();
        var rainBot = new Mock<RainBot>(printer.Object);
        var sunBot = new Mock<SunBot>(printer.Object);
        var snowBot = new Mock<SnowBot>(printer.Object);

        _weather.Object.AddBot(rainBot.Object);
        _weather.Object.AddBot(sunBot.Object);
        _weather.Object.AddBot(snowBot.Object);

        _weather.Object.UpdateWeatherState(_weatherData);

        rainBot.Verify(x => x.Update(_weatherData), Times.Once);
        sunBot.Verify(x => x.Update(_weatherData), Times.Once);
        snowBot.Verify(x => x.Update(_weatherData), Times.Once);
    }
}
