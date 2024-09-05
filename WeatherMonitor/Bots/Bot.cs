using Newtonsoft.Json;
using WeatherMonitor.ConfigData;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.WeatherManagement;
namespace WeatherMonitor.Bots;

public abstract class Bot
{
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;

    public void Update(WeatherData weatherData)
    {
        if(Enabled && IsActivated(weatherData))
            GetBotStatus();
    }

    protected abstract bool IsActivated(WeatherData weatherData);

    private void GetBotStatus(){
        Print.Log($"{GetType().Name} activated!");
        Print.Log(Message + Environment.NewLine);
    }
}

