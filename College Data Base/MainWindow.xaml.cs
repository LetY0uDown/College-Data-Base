namespace College_Data_Base;

using System.Windows;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();    
}