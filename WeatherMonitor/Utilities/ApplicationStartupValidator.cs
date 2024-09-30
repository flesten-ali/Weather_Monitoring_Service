using WeatherMonitor.PrintConfig;
using WeatherMonitor.Utilities.WrapperClasses;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities;

public static class ApplicationStartupValidator
{
    public static void StartApplication(WeatherBase weatherBase, IPrint print)
    {
        if (IsValidApp(out var weatherData))
        {
            SetUpApplicationWrapper.SetUpApplication(weatherBase, weatherData!);
            return;
        }
        print.Log("Please Enter Valid Input!");
    }

    private static bool IsValidApp(out WeatherData? weatherData)
    {
        weatherData = null;
        return IsValidateInput() && IsValidateFormat(out weatherData);
    }

    private static bool IsValidateFormat(out WeatherData? weatherData)
    {
        weatherData = FormatWrapper.GetDateFromInputFormat(InputWrapper.GetInput());
        return weatherData != null;
    }

    private static bool IsValidateInput()
    {
        return InputWrapper.ValidateInput();
    }
}
