using System.Xml.Serialization;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.InputData;

public class XmlInput : IInputData
{
    private readonly IPrint _printer;

    public XmlInput(IPrint print)
    {
        _printer = print;

    }
    
    public WeatherData? ParseData(string input)
    {
        WeatherData? weatherData = null;
        try
        {
            var serializer = new XmlSerializer(typeof(WeatherData));
            using var reader = new StringReader(input);
            weatherData = (WeatherData)serializer.Deserialize(reader)!;
        }
        catch
        {
            _printer.Log("Invalid Xml format");
        }
        return weatherData;
    }

    public bool IsMatch(string input)
    {
        return input.StartsWith('<') && input.EndsWith('>');
    }
}
