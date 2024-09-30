namespace WeatherMonitor.Tests.InputDataTests;

public abstract class InputBaseTest
{
    public abstract void ReturnWeatherData_When_InputStringIsValid();
    public abstract void ThrowException_When_StringIsInvalid();
}
