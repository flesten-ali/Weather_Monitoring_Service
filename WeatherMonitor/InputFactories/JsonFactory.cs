using WeatherMonitor.InputData;
namespace WeatherMonitor.InputFactories;

public class JsonFactory : InputFactory
{
    protected override IInputData Create()
    {
        return new JsonInput();
    }
}
