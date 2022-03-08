namespace College_Data_Base.MVVM.ViewModels;

using College_Data_Base.Core;
using College_Data_Base.Core.Managers;
using System.Windows;

public class LoginViewModel : ObservableObject
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
    }

    public Command ConnectCommand { get; init; }

    public Command GoOfflineCommand { get; init; } = new(o =>
    {
        ServerManager.ConnectOffline();
        StartApplication();
    });

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