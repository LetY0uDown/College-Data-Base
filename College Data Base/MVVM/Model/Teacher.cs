namespace College_Data_Base.MVVM.Model;

using College_Data_Base.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Teachers")]
public class Teacher : Entity
{
    [NotMapped]
    public string FullName => $"{MiddleName} {FirstName[0]}. {LastName[0]}.";

    public string FirstName { get; set; } = "null";
    public string MiddleName { get; set; } = "null";
    public string LastName { get; set; } = "null";

    [Column(TypeName = "Date")]
    public DateTime Birthday { get; set; } = DateTime.Now;

    public int? DisciplineID { get; set; }
    public Discipline? Discipline { get; set; }

    public Group? SupervisedGroup { get; set; }
}