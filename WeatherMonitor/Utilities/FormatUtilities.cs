using WeatherMonitor.InputData;
using WeatherMonitor.InputFactories;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities;

public static class FormatUtilities
{

    private static readonly List<IInputData> InputFormats =
    [
        new JsonFactory().GetObject(),
        new XmlFactory().GetObject()
    ];

    private static IInputData? GetInputFormat(string input)
    {
        var inputFormat = InputFormats.FirstOrDefault(format => format.IsMatch(input));
        return inputFormat;
    }

    public static WeatherData? GetDateFromInputFormat(string input)
    {
        var inputFormat = GetInputFormat(input);
        return inputFormat?.ParseDate(input);
    }
}
