using WeatherMonitor.InputData;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.InputFactories;

public class JsonFactory : InputFactory
{
    protected override IInputData Create()
    {
        return new JsonInput(new Print());
    }
}
