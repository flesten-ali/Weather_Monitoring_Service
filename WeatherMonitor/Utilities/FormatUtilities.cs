using WeatherMonitor.InputData;
using WeatherMonitor.InputFactories;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.Utilities;

public static class FormatUtilities
{

    private static readonly List<IInputData> InputFormats =
    [
        new JsonFactory().GetObject(),
        new XmlFactory().GetObject()
    ];

    public static IInputData? GetInputFormat(string input)
    {
        var inputFormat = InputFormats.FirstOrDefault(format => format.IsMatch(input));
        return inputFormat ;
    }

    private static void GetDateFromInputFormat(string input, IInputData format)
    {
        var parsedWeatherInput = format.GetDate(input);
        if (parsedWeatherInput is not null)
            ApplicationSetUp.SetUpApplication(parsedWeatherInput);
    }

    public static void ValidateFormat(string input, IInputData? inputFormat)
    {
        if (inputFormat is not null)
        {
            GetDateFromInputFormat(input, inputFormat);
            return;
        }
        Print.Log("Invalid Format!");
    }
}
