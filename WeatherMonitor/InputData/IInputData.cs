using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.InputData;

public interface IInputData
{
    WeatherData? ParseDate(string input);
    bool IsMatch(string input);
}
