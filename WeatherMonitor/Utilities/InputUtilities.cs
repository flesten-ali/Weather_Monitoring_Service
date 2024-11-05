using System.Text;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.Utilities.Interfaces;
namespace WeatherMonitor.Utilities;

public class InputUtilities : IInputUtilities
{
    public InputUtilities(IPrint print, IConsoleWrapper consoleWrapper)
    {
        _printer = print;
        _console = consoleWrapper;
    }

    public string Input
    {
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

    private string _input = string.Empty;
    private readonly IPrint _printer;
    private readonly IConsoleWrapper _console;
    private bool IsEntered { get; set; }

    private void EnterInput()
    {
        _printer.Log("Enter weather data:");
        var input = new StringBuilder();
        string line;

        while ((line = _console.ReadLine()!) != string.Empty)
        {
            input.AppendLine(line);
        }
        Input = input.ToString().Trim();
        IsEntered = true;
    }

    public bool ValidateInput()
    {
        return !string.IsNullOrEmpty(Input);
    }
}
