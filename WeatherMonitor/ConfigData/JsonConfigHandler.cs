using Newtonsoft.Json;
namespace WeatherMonitor.ConfigData;
#nullable disable
public abstract class JsonConfigHandler
{
    private const string FilePath = @"C:\Users\User\Desktop\FTS\WeatherService\WeatherMonitor\WeatherMonitor\ConfigData\data.json";

    public static void LoadConfiguration()
    {
        var jsonString = File.ReadAllText(FilePath);
        var configurationData = JsonConvert.DeserializeObject<ConfigurationData>(jsonString);
        SetUpConfigurationInstance(configurationData , ConfigurationData.ConfigurationDataInstance);
    }

    private static void SetUpConfigurationInstance(ConfigurationData configurationData, ConfigurationData configurationInstance)
    {
        configurationInstance.RainBot = configurationData.RainBot;
        configurationInstance.SnowBot = configurationData.SnowBot;
        configurationInstance.SunBot = configurationData.SunBot;
    }
}
