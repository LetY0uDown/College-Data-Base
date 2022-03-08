namespace College_Data_Base.MVVM.ViewModels;

using College_Data_Base.Core;
using System.Windows;

public class LoginViewModel : ViewModel
{
    public LoginViewModel()
    {
        ConnectCommand = new(o =>
        {
            ServerManager.InitializeConnection(ServerName!, Username!, Password!);

            if (ServerManager.TestConnection())
                StartApplication();

        }, b => ServerName is not null
                && Username is not null
                && Password is not null);

        GoOfflineCommand = new(o =>
        {
            ServerManager.OfflineConnection();

            if (ServerManager.TestConnection())
                StartApplication();
        });
    }

    public Command ConnectCommand { get; init; }

    public Command GoOfflineCommand { get; init; } 

    public Command ExitCommand { get; init; } = new(o =>
        Application.Current.Shutdown());
        
    public string? ServerName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    private static void StartApplication()
    {
        LoginWindow.Instance.Hide();
        Application.Current.MainWindow.Show();
    }
}