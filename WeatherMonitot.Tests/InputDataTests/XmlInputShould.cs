using FluentAssertions;
using Moq;
using WeatherMonitor.InputData;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.Tests.InputDataTests;

[Trait("Input", "XML")]
public class XmlInputShould : InputBaseTest
{
    private readonly XmlInput _xmlInput;
    private readonly Mock<IPrint> _printer;

    public XmlInputShould()
    {
        _printer = new Mock<IPrint>();
        _xmlInput = new XmlInput(_printer.Object);
    }

    [Fact]
    public override void ReturnWeatherData_When_InputStringIsValid()
    {
        var input = """
                    <WeatherData>
                      <Location>City Name</Location>
                      <Temperature>23.0</Temperature>
                      <Humidity>85.0</Humidity>
                    </WeatherData>
                    """;

        var res = _xmlInput.ParseData(input);

        res.Should().NotBeNull();
        res!.Temperature.Should().Be(23);
        res.Location.Should().Be("City Name");
        res.Humidity.Should().Be(85);
    }

    [Fact]
    public override void ReturnNull_When_InputStringIsInValid()
    {
        var res = _xmlInput.ParseData("");

        res.Should().BeNull();
    }

    [Fact]
    public override void PrintErrorMsg_When_StringIsInvalid()
    {
        var res = _xmlInput.ParseData("");

        res.Should().BeNull();
        _printer.Verify(x => x.Log("Invalid Xml format"), Times.Once);
    }

    [Fact]
    public void ReturnTrue_When_StringMatchXml()
    {
        var isXml = _xmlInput.IsMatch("<>");

        isXml.Should().BeTrue();
    }

    [Fact]
    public void ReturnFalst_When_StringDoesNotMatchXml()
    {
        var isXml = _xmlInput.IsMatch("/");

        isXml.Should().BeFalse();
    }
}
