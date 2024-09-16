using FluentAssertions;
using Moq;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.Utilities;
using WeatherMonitor.Utilities.Interfaces;
namespace WeatherMonitor.Tests.UtilitiesTests;

public class InputUtilitiesShould
{
    private readonly Mock<IPrint> _printer;
    private readonly Mock<IConsoleWrapper> _console;
    private readonly Mock<InputUtilities> _input;

    public InputUtilitiesShould()
    {
        _printer = new Mock<IPrint>();
        _console = new Mock<IConsoleWrapper>();

        _console.SetupSequence(x => x.ReadLine()).Returns("input").Returns("");
        _input = new Mock<InputUtilities>(_printer.Object, _console.Object);
    }

    [Fact]
    public void CallLog_When_EnterInputIsCalled()
    {
        var res = _input.Object.Input;

        _printer.Verify(x => x.Log("Enter weather data:"), Times.Once);
    }
    [Fact]
    public void CallConsole_When_EnterInputIsCalled()
    {
        var res = _input.Object.Input;

        _console.Verify(x => x.ReadLine(), Times.Exactly(2));
    }
    [Fact]
    public void ReturnUserInput_When_Entered()
    {
        var res = _input.Object.Input;

        res.Should().NotBeNull();
        res.Should().Be("input");
    }
    [Fact]
    public void ReturnTrue_When_ValidateNonEmptyString()
    {
        var res = _input.Object.ValidateInput();

        res.Should().BeTrue();
    }

    [Fact]
    public void ReturnFalse_When_ValidateEmptyString()
    {
        _console.Setup(x => x.ReadLine()).Returns("");

        var res = _input.Object.ValidateInput();

        res.Should().BeFalse();
    }
}
