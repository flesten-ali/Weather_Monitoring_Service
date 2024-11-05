using WeatherMonitor.Utilities.Interfaces;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities.WrapperClasses;

public static class SetUpApplicationWrapper
{
    private static IApplicationSetUp _applicationSetUp;

    public static void SetApplicaton(IApplicationSetUp applicationSetUp)
    {
        _applicationSetUp = applicationSetUp;
    }

    public static void SetUpApplication(WeatherBase weatherBase, WeatherData weatherData)
    {
        _applicationSetUp.SetUpApplication(weatherBase, weatherData);
    }
}
