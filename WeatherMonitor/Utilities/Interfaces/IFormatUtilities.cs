using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities.Interfaces;

public interface IFormatUtilities
{
    WeatherData? GetDateFromInputFormat(string input);
}