namespace College_Data_Base.MVVM.Model;

using College_Data_Base.Core;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Groups")]
public class Group : Entity
{
    public string Title { get; set; } = "null";

    public int? CuratorID { get; set; }
    public Teacher? Curator { get; set; }

    public ObservableCollection<Student>? Students { get; set; }
}