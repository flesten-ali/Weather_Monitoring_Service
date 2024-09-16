namespace WeatherMonitor.Utilities.Interfaces;
public interface IInputUtilities
{
    string Input { get; }

    bool ValidateInput();
}