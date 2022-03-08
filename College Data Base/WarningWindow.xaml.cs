namespace College_Data_Base;

using System.Windows;

public partial class WarningWindow : Window
{
    public WarningWindow(string title, string message)
    {
        InitializeComponent();

        Title = title;
        Message = message;
    }

    private new string Title
    {
        init => TitleLabel.Content = value;
    }

    private string Message
    {
        init => TextTB.Text = value;
    }

    private void Button_Click(object sender, RoutedEventArgs e) => Hide();
}