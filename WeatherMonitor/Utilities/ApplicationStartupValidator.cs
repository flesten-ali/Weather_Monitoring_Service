using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities;

public static class ApplicationStartupValidator
{
    public static void StartApplication()
    {
        if (IsValidApp(out var weatherData))
        {
            ApplicationSetUp.SetUpApplication(weatherData!);
            return;
        }
        Print.Log("Please Enter Valid Input!");
    }

    private static bool IsValidApp(out WeatherData? weatherData)
    {
        if (!InputUtilities.ValidateInput())
        {
            weatherData = null;
            return false;
        }
        weatherData = FormatUtilities.GetDateFromInputFormat(InputUtilities.Input);
        return weatherData != null;
    }
}
