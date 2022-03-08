namespace College_Data_Base.Core;

public abstract class ViewModel : ObservableObject
{
    public virtual Command? AddCommand { get; protected init; }
    public virtual Command? SaveCommand { get; protected init; }
    public virtual Command? DeleteCommand { get; protected init; }

    protected bool _isInputEnabled = false;
    public bool IsInputEnabled
    {
        get => _isInputEnabled;
        protected set
        {
            _isInputEnabled = value;
            OnPropertyChanged();
        }
    }
}