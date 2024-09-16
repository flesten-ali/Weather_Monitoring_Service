namespace WeatherMonitor.Tests.InputDataTests;

public abstract class InputBaseTest
{
    public abstract void ReturnWeatherData_When_InputStringIsValid();
    public abstract void ReturnNull_When_InputStringIsInValid();
    public abstract void PrintErrorMsg_When_StringIsInvalid();
}
