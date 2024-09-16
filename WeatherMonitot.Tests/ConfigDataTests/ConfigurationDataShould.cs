using WeatherMonitor.ConfigData;
namespace WeatherMonitor.Tests.ConfigDataTests;

public class ConfigurationDataShould
{
    [Fact]
    public void ReturnOneInstance()
    {
        var instance1 = ConfigurationData.ConfigurationDataInstance;
        var instance2 = ConfigurationData.ConfigurationDataInstance;
        Assert.Same(instance1, instance2);
    }
}
