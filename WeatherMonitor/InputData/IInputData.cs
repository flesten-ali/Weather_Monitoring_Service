using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.InputData;

public interface IInputData
{
    WeatherData? GetDate(string input);
    bool IsMatch(string input);
}
