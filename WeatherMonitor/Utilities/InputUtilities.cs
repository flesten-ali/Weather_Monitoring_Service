using System.Text;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.Utilities;

public static class InputUtilities
{
    public static string Input {
        get
        {
            if (!IsEntered)
            {
                EnterInput();
            }
            return _input;
        }
        private set => _input = value;
    }

    private static string _input = string.Empty;
    private static bool IsEntered { get; set; }

    private static void EnterInput()
    {
        Print.Log("Enter weather data:");
        var input = new StringBuilder();
        string line;

        while ((line = Console.ReadLine()!) != string.Empty)
        {
            input.AppendLine(line);
        }
        Input = input.ToString().Trim();
        IsEntered = true;
    }
    
    public static bool ValidateInput()
    {
        return !string.IsNullOrEmpty(Input);
    }
}
