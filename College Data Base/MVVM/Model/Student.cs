namespace College_Data_Base.MVVM.Model;

using College_Data_Base.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Students")]
public class Student : Entity
{
    public string FirstName { get; set; } = "null";
    public string MiddleName { get; set; } = "null";
    public string LastName { get; set; } = "null";

    [Column(TypeName = "Date")]
    public DateTime Birthday { get; set; } = DateTime.Now;

    public int? GroupID { get; set; }
    public Group? Group { get; set; }
}