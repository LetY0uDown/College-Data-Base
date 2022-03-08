namespace College_Data_Base.MVVM.Model;

using College_Data_Base.Core;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Disciplines")]
public class Discipline : Entity
{
    public string Title { get; set; } = "null";

    public Teacher? Teacher { get; set; }
}