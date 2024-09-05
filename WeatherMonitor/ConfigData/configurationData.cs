using WeatherMonitor.BotFactory;
using WeatherMonitor.Bots;
namespace WeatherMonitor.ConfigData;

public sealed class ConfigurationData
{
    public Bot RainBot { get; set; } = new RainBotFactory().GetBot();
    public Bot SunBot { get; set; } = new SunBotFactory().GetBot();
    public Bot SnowBot { get; set; } = new SnowBotFactory().GetBot();

    public static ConfigurationData ConfigurationDataInstance => LazyConfigurationData.Value;

    private static readonly Lazy<ConfigurationData> LazyConfigurationData = new Lazy<ConfigurationData>(new ConfigurationData());

    private ConfigurationData() { }
}
