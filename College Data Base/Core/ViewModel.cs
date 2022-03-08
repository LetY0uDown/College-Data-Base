namespace College_Data_Base.Core;

using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// Base class for a View Model
/// </summary>
public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}