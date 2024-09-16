using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace WeatherMonitor.ConfigData;
#nullable disable
public class JsonConfigHandler : IJsonConfigHandler
{
    private const string FilePath = @"ConfigData\data.json";
    private readonly IFileSystem _fileSystem;

    public JsonConfigHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void LoadConfiguration()
    {
        var jsonString = _fileSystem.ReadAllText(FilePath);
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };
        var configurationData = JsonConvert.DeserializeObject<ConfigurationData>(jsonString, settings);
        SetUpConfigurationInstance(configurationData, ConfigurationData.ConfigurationDataInstance);
    }

    private static void SetUpConfigurationInstance(ConfigurationData configurationData, ConfigurationData configurationInstance)
    {
        configurationInstance.RainBot = configurationData.RainBot;
        configurationInstance.SnowBot = configurationData.SnowBot;
        configurationInstance.SunBot = configurationData.SunBot;
    }
}
