using WeatherMonitor.InputData;
namespace WeatherMonitor.InputFactories;

public class XmlFactory : InputFactory
{
    protected override IInputData Create()
    {
      return new XmlInput();
    }
}
