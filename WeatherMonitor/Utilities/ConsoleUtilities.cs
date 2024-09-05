using System.Text;
using WeatherMonitor.PrintConfig;
namespace WeatherMonitor.Utilities;

public abstract class ConsoleUtilities
{
    public static void StartApplication()
    {
        var input = EnterInput();
        ValidateInput(input);
    }

    private static string EnterInput()
    {
        Print.Log("Enter weather data:");
        var input = new StringBuilder();
        string line;

        while ((line = Console.ReadLine()!) != string.Empty)
        {
            input.AppendLine(line);
        }
        return input.ToString().Trim();
    }

    private static void ValidateInput(string input)
    {
        if (input == string.Empty)
        {
            Print.Log("Please Enter valid input");
            return;
        }
        GetInputFormat(input);
    }

    private static void GetInputFormat(string input)
    {
        var inputFormat = FormatUtilities.GetInputFormat(input);
    
        FormatUtilities.ValidateFormat(input, inputFormat);

    }
}
