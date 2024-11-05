using WeatherMonitor.Utilities.Interfaces;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Utilities.WrapperClasses;

public static class FormatWrapper
{
    private static IFormatUtilities _formatUtilities;

    public static void SetFormatUtilities(IFormatUtilities formatUtilities)
    {
        _formatUtilities = formatUtilities;
    }

    public static WeatherData? GetDateFromInputFormat(string input)
    {
        return _formatUtilities.GetDateFromInputFormat(input);
    }
}
