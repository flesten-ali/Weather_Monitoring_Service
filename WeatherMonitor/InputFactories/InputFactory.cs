using WeatherMonitor.InputData;
namespace WeatherMonitor.InputFactories;

public abstract class InputFactory
{
    protected abstract IInputData Create();
    public IInputData GetObject()
    {
       var instance = Create();
        return instance;
    }
}
