using Ninject;
using Ninject.Extensions.Conventions;
using WeatherMonitor.InputData;
using WeatherMonitor.PrintConfig;
using WeatherMonitor.Utilities;
using WeatherMonitor.Utilities.Interfaces;
using WeatherMonitor.Utilities.WrapperClasses;
using WeatherMonitor.WeatherManagement;

public class Program
{
    public static void Main()
    {
        var container = ConfigureContainer();

        SetUpWrappers(container);

        Start(container);
    }

    private static StandardKernel ConfigureContainer()
    {
        var container = new StandardKernel();

        container.Bind(p =>
        {
            p.FromThisAssembly()
            .SelectAllClasses()
            .BindDefaultInterface();
        });

        container.Bind<IInputData>().To(typeof(JsonInput));
        container.Bind<IInputData>().To(typeof(XmlInput));
        container.Bind<WeatherBase>().To(typeof(Weather));

        return container;
    }

    private static void SetUpWrappers(StandardKernel container)
    {
        InputWrapper.SetInputUtilities(container.Get<IInputUtilities>());
        FormatWrapper.SetFormatUtilities(container.Get<IFormatUtilities>());
    }

    private static void Start(StandardKernel container)
    {
        ApplicationStartupValidator.StartApplication(container.Get<WeatherBase>(), container.Get<IPrint>());
    }
}