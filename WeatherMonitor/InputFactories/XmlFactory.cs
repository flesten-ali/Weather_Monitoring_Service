using WeatherMonitor.InputData;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.InputFactories;

public class XmlFactory : InputFactory
{
    protected override IInputData Create()
    {
      return new XmlInput(new Print());
    }
}
