using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities.Interfaces;

public interface IApplicationSetUp
{
    void SetUpApplication(WeatherBase weatherBase, WeatherData weatherData);
}