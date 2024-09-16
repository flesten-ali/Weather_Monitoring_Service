using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitor.InputData;
using WeatherMonitor.Utilities;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Tests.UtilitiesTests;

public class FormatUtilitiesShould
{
    private readonly Mock<IInputData> _jsonInput;
    private readonly Mock<IInputData> _xmlInput;
    private readonly Mock<FormatUtilities> _formater;

    private readonly WeatherData _dummyWeatherData;

    public FormatUtilitiesShould()
    {
        _jsonInput = new Mock<IInputData>();
        _xmlInput = new Mock<IInputData>();

        var fixture = new Fixture();
        _dummyWeatherData = fixture.Create<WeatherData>();

        _jsonInput.Setup(x => x.IsMatch(It.IsAny<string>())).Returns(true);
        _jsonInput.Setup(x => x.ParseData(It.IsAny<string>())).Returns(_dummyWeatherData);
        _xmlInput.Setup(x => x.IsMatch(It.IsAny<string>())).Returns(false);

        _formater = new Mock<FormatUtilities>(new List<IInputData> { _jsonInput.Object, _xmlInput.Object });
    }

    [Fact]
    public void ReturnWeatherData_When_GetDateFromInputFormatCalledAndInputIsMatch()
    {
        var weatherData = _formater.Object.GetDateFromInputFormat(It.IsAny<string>());

        _jsonInput.Verify(x => x.IsMatch(It.IsAny<string>()), Times.Once);
        weatherData.Should().NotBeNull();
        weatherData!.Humidity.Should().Be(_dummyWeatherData.Humidity);
        weatherData.Location.Should().Be(_dummyWeatherData.Location);
        weatherData.Temperature.Should().Be(_dummyWeatherData.Temperature);
    }

    [Fact]
    public void ReturnNull_When_InputDoesNotMatch()
    {
        _jsonInput.Setup(x => x.IsMatch(It.IsAny<string>())).Returns(false);

        var weatherData = _formater.Object.GetDateFromInputFormat(It.IsAny<string>());

        _jsonInput.Verify(x => x.IsMatch(It.IsAny<string>()), Times.Once);
        _xmlInput.Verify(x => x.IsMatch(It.IsAny<string>()), Times.Once);
        weatherData.Should().BeNull();
    }
}
