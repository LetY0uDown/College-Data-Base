namespace College_Data_Base.MVVM.ViewModels;

using College_Data_Base.Core;
using College_Data_Base.Core.Managers;
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

    private Teacher? _selectedTeacher;
    public Teacher? SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            _selectedTeacher = value;

            IsInputEnabled = value is not null;

            OnPropertyChanged();
        }
    }
}