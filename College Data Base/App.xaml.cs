namespace College_Data_Base;

using System.Windows;

public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        LoginWindow.Instance.Show();

        Current.MainWindow = new MainWindow();
    }
}