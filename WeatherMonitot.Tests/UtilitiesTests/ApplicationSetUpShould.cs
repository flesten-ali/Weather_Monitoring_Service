using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitor.Bots;
using WeatherMonitor.ConfigData;
using WeatherMonitor.Utilities;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Tests.UtilitiesTests;

public class ApplicationSetUpShould
{
    private readonly Mock<IJsonConfigHandler> _handler;
    private readonly Mock<WeatherBase> _weather;
    private readonly ApplicationSetUp _appSetUp;
    private readonly WeatherData _weatherData;

    private const int NumberOfBots = 3;

    public ApplicationSetUpShould()
    {
        _handler = new Mock<IJsonConfigHandler>();
        _appSetUp = new ApplicationSetUp(_handler.Object);
        _weather = new Mock<WeatherBase>();

        _weather.Setup(x => x.UpdateWeatherState(It.IsAny<WeatherData>()));

        var fixture = new Fixture();
        _weatherData = fixture.Create<WeatherData>();
    }

    [Fact]
    public void ShouldCallLoadConfiguration()
    {
        _appSetUp.SetUpApplication(_weather.Object, _weatherData);

        _handler.Verify(x => x.LoadConfiguration(), Times.Once());
    }

    [Fact]
    public void ShouldCallUpdateWeatherState()
    {
        _appSetUp.SetUpApplication(_weather.Object, _weatherData);

        _weather.Verify(x => x.UpdateWeatherState(_weatherData), Times.Once());
    }

    [Fact]
    public void ShouldAddAllBots()
    {
        _appSetUp.SetUpApplication(_weather.Object, _weatherData);

        _weather.Object.Bots.Count.Should().Be(NumberOfBots);
    }
}
