using WeatherMonitor.InputData;
using WeatherMonitor.Utilities.Interfaces;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities;

public class FormatUtilities : IFormatUtilities
{
    private readonly List<IInputData> _inputFormats;

    public FormatUtilities(List<IInputData> inputFormats)
    {
        _inputFormats = inputFormats;
    }

    public WeatherData? GetDateFromInputFormat(string input)
    {
        var inputFormat = GetInputFormat(input);
        return inputFormat?.ParseData(input);
    }

    private IInputData? GetInputFormat(string input)
    {
        var inputFormat = _inputFormats.FirstOrDefault(format => format.IsMatch(input));
        return inputFormat;
    }
}
