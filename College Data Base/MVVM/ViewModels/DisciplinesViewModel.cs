namespace College_Data_Base.MVVM.ViewModels;

using College_Data_Base.Core;
using College_Data_Base.Core.Managers;
using College_Data_Base.MVVM.Model;
using System.Collections.ObjectModel;

public class DisciplinesViewModel : ViewModel
{
    public DisciplinesViewModel()
    {
        AddCommand = new(o =>
        {
            Discipline discipline = new();

            DataManager.AddEntity<Discipline>(discipline);
            Disciplines.Add(discipline);

            SelectedDiscipline = discipline;

        }, b => !IsInputEnabled);

        SaveCommand = new(o =>
        {
            DataManager.UpdateEntity<Discipline>(SelectedDiscipline!);
            SelectedDiscipline = null;

        }, b => IsInputEnabled);

        DeleteCommand = new(o =>
        {
            DataManager.RemoveEntity<Discipline>(SelectedDiscipline!);
            Disciplines.Remove(SelectedDiscipline!);

            SelectedDiscipline = null;

        }, b => IsInputEnabled);
    }

    public ObservableCollection<Discipline> Disciplines { get; set; } = DataManager.GetCollection<Discipline>();

    private Discipline? _selectedDiscipline;
    public Discipline? SelectedDiscipline
    {
        get => _selectedDiscipline;
        set
        {
            _selectedDiscipline = value;

            if (value is not null)
                _selectedDiscipline!.Teachers = DataManager.SelectTeachersByDiscipline(value);

            IsInputEnabled = value is not null;

            OnPropertyChanged();
        }
    }
}