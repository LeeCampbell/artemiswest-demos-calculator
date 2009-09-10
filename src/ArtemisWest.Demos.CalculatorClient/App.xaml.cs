using System.IO;

namespace ArtemisWest.Demos.CalculatorClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //Would normally use an ILogger Interface as an adapter to a standard Logging library (EntLib, Log4Net, NLog...)
            using (var writer = File.AppendText("Error.log"))
            {
                writer.WriteLine(e.Exception);
            }
            System.Windows.MessageBox.Show("An unhandled exception occured. The application is shutting down.");
            e.Handled = true;
            Shutdown(-1);
        }
    }
}
