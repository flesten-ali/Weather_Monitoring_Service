using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.InputData;

public interface IInputData
{
    WeatherData? ParseData(string input);

    bool IsMatch(string input);
}
