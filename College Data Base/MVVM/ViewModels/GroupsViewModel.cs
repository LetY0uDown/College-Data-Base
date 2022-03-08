namespace College_Data_Base.MVVM.ViewModels;

using College_Data_Base.Core;
using College_Data_Base.Core.Managers;
using College_Data_Base.MVVM.Model;
using System.Collections.ObjectModel;

public class GroupsViewModel : ViewModel
{
    public GroupsViewModel()
    {
        AddCommand = new(o =>
        {
            var group = new Group();

            DataManager.AddEntity<Group>(group);
            Groups.Add(group);

            SelectedGroup = group;

        }, b => !IsInputEnabled);

        SaveCommand = new(o =>
        {
            DataManager.UpdateEntity<Group>(SelectedGroup!);
            SelectedGroup = null;

        }, b => IsInputEnabled);

        DeleteCommand = new(o =>
        {
            DataManager.RemoveEntity<Group>(SelectedGroup!);
            Groups.Remove(SelectedGroup!);

            SelectedGroup = null;

        }, b => IsInputEnabled);
    }

    public ObservableCollection<Group> Groups { get; set; } = DataManager.GetCollection<Group>();

    public ObservableCollection<Teacher> Curators { get; set; } = DataManager.SelectAvailableCurators();

    private Group? _selectedGroup;
    public Group? SelectedGroup
    {
        get => _selectedGroup;
        set
        {
            _selectedGroup = value;

            if (value is not null)
                _selectedGroup!.Students = DataManager.SelectStudentsByGroup(value);

            IsInputEnabled = value is not null;

            Curators = DataManager.SelectAvailableCurators();

            OnPropertyChanged();
        }
    }
}