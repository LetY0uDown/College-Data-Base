namespace College_Data_Base.MVVM.ViewModels;

using College_Data_Base.Core;
using College_Data_Base.MVVM.Model;
using System.Collections.ObjectModel;

public class StudentsViewModel : ViewModel
{
    public StudentsViewModel()
    {
        AddCommand = new(o =>
        {
            Student student = new();

            DataManager.AddEntity<Student>(student);
            Students.Add(student);

            SelectedStudent = student;

        }, b => !IsInputEnabled);

        SaveCommand = new(o =>
        {
            DataManager.UpdateEntity<Student>(SelectedStudent!);
            SelectedStudent = null;

        }, b => IsInputEnabled);

        DeleteCommand = new(o =>
        {
            DataManager.RemoveEntity<Student>(SelectedStudent!);
            Students.Remove(SelectedStudent!);

            SelectedStudent = null;

        }, b => IsInputEnabled);
    }

    public ObservableCollection<Student> Students { get; set; } = DataManager.GetCollection<Student>();
    public ObservableCollection<Group> Groups { get; set; } = DataManager.GetCollection<Group>();

    public Command AddCommand { get; init; }
    public Command SaveCommand { get; init; }
    public Command DeleteCommand { get; init; }

    private bool _isInputEnabled = false;
    public bool IsInputEnabled
    {
        get => _isInputEnabled;
        private set
        {
            _isInputEnabled = value;
            OnPropertyChanged();
        }
    }

    private Student? _selectedStudent;
    public Student? SelectedStudent
    {
        get => _selectedStudent;
        set
        {
            _selectedStudent = value;

            IsInputEnabled = value is not null;

            OnPropertyChanged();
        }
    }
}