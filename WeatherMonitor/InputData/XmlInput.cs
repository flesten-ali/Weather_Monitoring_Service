using System.Xml.Serialization;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.InputData;

public class XmlInput : IInputData
{
    public WeatherData? GetDate(string input)
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
            Print.Log("Invalid Xml format");
        }
        return weatherData;
    }

    public bool IsMatch(string input)
    {
        return input.StartsWith('<') && input.EndsWith('>');
    }
}
