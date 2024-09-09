using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace WeatherMonitor.ConfigData;
#nullable disable
public abstract class JsonConfigHandler
{
    private const string FilePath = @"ConfigData\data.json";

    public static void LoadConfiguration()
    {
        var jsonString = File.ReadAllText(FilePath);
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };
        var configurationData = JsonConvert.DeserializeObject<ConfigurationData>(jsonString, settings);
        SetUpConfigurationInstance(configurationData , ConfigurationData.ConfigurationDataInstance);
    }

    private static void SetUpConfigurationInstance(ConfigurationData configurationData, ConfigurationData configurationInstance)
    {
        configurationInstance.RainBot = configurationData.RainBot;
        configurationInstance.SnowBot = configurationData.SnowBot;
        configurationInstance.SunBot = configurationData.SunBot;
    }
}
