using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Bots;

public abstract class Bot
{
    public bool Enabled { get; set; }
    public string Message { get; set; } = string.Empty;
    private readonly IPrint _printer;

    public Bot(IPrint print)
    {
        _printer = print;
    }

    public virtual void Update(WeatherData weatherData)
    {
        if (Enabled && IsActivated(weatherData))
            GetBotStatus();
    }

    protected abstract bool IsActivated(WeatherData weatherData);

    private void GetBotStatus()
    {
        _printer.Log($"{GetType().Name} activated!");
        _printer.Log(Message + Environment.NewLine);
    }
}

