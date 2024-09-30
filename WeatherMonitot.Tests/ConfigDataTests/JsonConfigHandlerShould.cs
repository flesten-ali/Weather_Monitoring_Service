using FluentAssertions;
using Moq;
using WeatherMonitor.Bots;
using WeatherMonitor.ConfigData;
namespace WeatherMonitor.Tests.ConfigDataTests;

public class JsonConfigHandlerShould
{
    private readonly JsonConfigHandler _jsonHandler;
    private readonly ConfigurationData _configurationData;
    private const string JsonString = """
                                       {
                                         RainBot: {},
                                         sunBot:{},
                                         snowBot:{}
                                       }
                                       """;
    public JsonConfigHandlerShould()
    {
        Mock<IFileSystem> fileSystem = new();
        fileSystem.Setup(x => x.ReadAllText(It.IsAny<string>())).Returns(JsonString);
        _jsonHandler = new JsonConfigHandler(fileSystem.Object);
        _configurationData = ConfigurationData.ConfigurationDataInstance;
    }

    [Fact]
    public void DeserializeConfigurationDataCorrectly()
    {
        _jsonHandler.LoadConfiguration();

        _configurationData.Should().NotBeNull();
        _configurationData.RainBot.Should().NotBeNull().And.BeOfType<RainBot>();
        _configurationData.SnowBot.Should().NotBeNull().And.BeOfType<SnowBot>();
        _configurationData.SunBot.Should().NotBeNull().And.BeOfType<SunBot>();
    }
}
