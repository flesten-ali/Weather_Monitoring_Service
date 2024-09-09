using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.WeathersFactory;

public class WeatherFactory
{
    public static Weather CreateWeather()
    {
        return new Weather();
    }
}
