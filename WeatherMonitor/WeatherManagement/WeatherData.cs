namespace WeatherMonitor.WeatherManagement;

public class WeatherData
{
    public string Location { get; init; } = string.Empty;
    public double Temperature { get; init; }
    public double Humidity { get; init; }
}