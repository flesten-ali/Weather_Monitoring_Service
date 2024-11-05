using WeatherMonitor.Utilities.Interfaces;

namespace WeatherMonitor.Utilities.WrapperClasses;

public static class InputWrapper
{
    private static IInputUtilities _inputUtilities;
    public static void SetInputUtilities(IInputUtilities inputUtilities)
    {
        _inputUtilities = inputUtilities;
    }
    public static string GetInput()
    {
        return _inputUtilities.Input;
    }
    public static bool ValidateInput()
    {
        return _inputUtilities.ValidateInput();
    }
}
