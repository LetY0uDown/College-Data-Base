namespace College_Data_Base.MVVM.ViewModels;

using College_Data_Base.Core;
using College_Data_Base.MVVM.Model;
using System.Collections.ObjectModel;

public class TeachersViewModel : ViewModel
{
    public TeachersViewModel()
    {
        AddCommand = new(o =>
        {
            Teacher teacher = new();

            DataManager.AddEntity<Teacher>(teacher);
            Teachers.Add(teacher);

            SelectedTeacher = teacher;

        }, b => !IsInputEnabled);

        SaveCommand = new(o =>
        {
            DataManager.UpdateEntity<Teacher>(SelectedTeacher!);
            SelectedTeacher = null;

        }, b => IsInputEnabled);

        DeleteCommand = new(o =>
        {
            DataManager.RemoveEntity<Teacher>(SelectedTeacher!);
            Teachers.Remove(SelectedTeacher!);

            SelectedTeacher = null;

        }, b => IsInputEnabled);        
    }

    public ObservableCollection<Teacher> Teachers { get; set; } = DataManager.GetCollection<Teacher>();
    public ObservableCollection<Discipline> Disciplines { get; set; } = DataManager.GetCollection<Discipline>();

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

    private Teacher? _selectedTeacher;
    public Teacher? SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            _selectedTeacher = value;

            if (value is not null)
                _selectedTeacher!.SupervisedGroup = DataManager.SelectGroupByID(SelectedTeacher!.ID);

            IsInputEnabled = value is not null;

            OnPropertyChanged();
        }
    }
}