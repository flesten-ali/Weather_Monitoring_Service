using AutoFixture;
using Moq;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.Utilities;
using WeatherMonitor.Utilities.Interfaces;
using WeatherMonitor.Utilities.WrapperClasses;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Tests.UtilitiesTests;

public class ApplicationValidatorShould
{
    private readonly Mock<IPrint> _printer;
    private readonly Mock<IInputUtilities> _input;
    private readonly Mock<IApplicationSetUp> _setUp;

    private readonly WeatherBase _weather;
    private readonly WeatherData _weatherData;

    public ApplicationValidatorShould()
    {
        _printer = new Mock<IPrint>();
        _weather = new Mock<WeatherBase>().Object;
        _input = new Mock<IInputUtilities>();

        Mock<IFormatUtilities> formater = new();
        _setUp = new Mock<IApplicationSetUp>();

        var fixture = new Fixture();
        _weatherData = fixture.Create<WeatherData>();

        _input.Setup(x => x.ValidateInput()).Returns(true);
        _input.Setup(x => x.Input).Returns("valid input");
        formater.Setup(x => x.GetDateFromInputFormat(_input.Object.Input)).Returns(_weatherData);

        InputWrapper.SetInputUtilities(_input.Object);
        FormatWrapper.SetFormatUtilities(formater.Object);
        SetUpApplicationWrapper.SetApplicaton(_setUp.Object);
    }

    [Fact]
    public void CallSetUpApplication_When_AppIsValid()
    {
        ApplicationStartupValidator.StartApplication(_weather, _printer.Object);

        _setUp.Verify(x => x.SetUpApplication(_weather, _weatherData), Times.Once);
    }

    [Fact]
    public void ShouldNotCallSetUpApplication_When_AppIsNotValid()
    {
        _input.Setup(x => x.ValidateInput()).Returns(false);

        ApplicationStartupValidator.StartApplication(_weather, _printer.Object);

        _setUp.Verify(x => x.SetUpApplication(_weather, _weatherData), Times.Never);
    }

    [Fact]
    public void ShouldPrintErrorMessage_When_AppIsNotValid()
    {
        _input.Setup(x => x.ValidateInput()).Returns(false);

        ApplicationStartupValidator.StartApplication(_weather, _printer.Object);

        _printer.Verify(x => x.Log("Please Enter Valid Input!"), Times.Once);
    }
}
