using FluentAssertions;
using Moq;
using WeatherMonitor.InputData;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.Tests.InputDataTests;

[Trait("Input", "JSON")]
public class JsonInputShould : InputBaseTest
{
    private readonly JsonInput _jsonInput;
    private readonly Mock<IPrint> _printer;

    public JsonInputShould()
    {
        _printer = new Mock<IPrint>();
        _jsonInput = new JsonInput(_printer.Object);
    }

    [Fact]
    public override void ReturnWeatherData_When_InputStringIsValid()
    {
         var input = """
                     {
                       "Location": "City Name",
                       "Temperature": 23.0,
                       "Humidity": 85.0
                     }
                     """;

        var res = _jsonInput.ParseData(input);

        res.Should().NotBeNull();
        res!.Temperature.Should().Be(23);
        res.Location.Should().Be("City Name");
        res.Humidity.Should().Be(85);
    }

    [Fact]
    public override void ReturnNull_When_InputStringIsInValid()
    {
        var res = _jsonInput.ParseData("");

        res.Should().BeNull();
    }

    [Fact]
    public override void PrintErrorMsg_When_StringIsInvalid()
    {
        var res = _jsonInput.ParseData("");

        res.Should().BeNull();
        _printer.Verify(x => x.Log("Invalid Json Format"), Times.Once);
    }

    [Theory]
    [InlineData("{}")]
    [InlineData("{1223}")]
    [InlineData("{Hello}")]
    [InlineData("{{}}")]
    public void ReturnTrue_When_StringMatchJson(string input)
    {
        var isJson = _jsonInput.IsMatch(input);

        isJson.Should().BeTrue();
    }

    [Theory]
    [InlineData("{-")]
    [InlineData("{1223")]
    [InlineData("Hello}")]
    [InlineData("}}")]
    public void ReturnFalse_When_StringDoesNotMatchJson(string input)
    {
        var isJson = _jsonInput.IsMatch(input);

        isJson.Should().BeFalse();
    }
}
