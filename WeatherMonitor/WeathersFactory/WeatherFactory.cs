using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.WeathersFactory;

public abstract class WeatherFactory
{
    public static Weather CreateWeather()
    {
        return new Weather();
    }
}
