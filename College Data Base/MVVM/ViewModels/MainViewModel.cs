namespace College_Data_Base.MVVM.ViewModels;

using College_Data_Base.Core;
using College_Data_Base.MVVM.Views;
using System.Windows;
using System.Windows.Controls;

public class MainViewModel : ViewModel
{
    public MainViewModel()
    {
        CurrentPage = new GradebookPage();

        ViewDisciplinesCommand = new(o =>
            CurrentPage = new DisciplinesListPage());

        ViewStudentsCommand = new(o =>
            CurrentPage = new StudentsListPage());

        ViewTeachersCommand = new(o =>
            CurrentPage = new TeachersListPage());

        ViewGroupsCommand = new(o =>
            CurrentPage = new GroupsListPage());

        ViewGradebookCommand = new(o =>
            CurrentPage = new GradebookPage());
    }

    public Command ViewDisciplinesCommand { get; init; }
    public Command ViewTeachersCommand { get; init; }
    public Command ViewStudentsCommand { get; init; }
    public Command ViewGroupsCommand { get; init; }
    public Command ViewGradebookCommand { get; init; }

        #region Region: App State Commands
    public Command ExitCommand { get; init; } = new(o =>
        Application.Current.Shutdown());

    public Command MaximizeCommand { get; init; } = new(o =>
        Application.Current.MainWindow.WindowState = 
            Application.Current.MainWindow.WindowState == WindowState.Normal ?
                WindowState.Maximized : WindowState.Normal);

    public Command MinimizeCommand { get; init; } = new(o =>
        Application.Current.MainWindow.WindowState = WindowState.Minimized);
    #endregion    

    private Page? _currentPage;
    public Page? CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;
            OnPropertyChanged();
        }
    }
}