namespace College_Data_Base;

using System.Windows;

public partial class LoginWindow : Window
{
    private LoginWindow() => InitializeComponent();    

    private static readonly LoginWindow _instance = new();
    public static LoginWindow Instance => _instance;
}
