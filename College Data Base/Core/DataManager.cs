namespace College_Data_Base.Core;

using College_Data_Base.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;

public static class DataManager
{
    public static ObservableCollection<Teacher> SelectAvailableCurators()
    {
        var collection = GetCollection<Group>();

        var curators = from g in collection where g.Curator?.ID is null select g.Curator;

        return new ObservableCollection<Teacher>(curators);
    }

    public static Group SelectGroupByID(int? id)
    {
        var collection = GetCollection<Group>();

        var group = (from g in collection where g.ID == id select g).FirstOrDefault();

        return group!;
    }

    public static ObservableCollection<Student> SelectStudentsByGroup(int id)
    {
        var collection = GetCollection<Student>();

        var students = from s in collection where s.GroupID == id select s;

        return new ObservableCollection<Student>(students);

        /*
         * Можно конечно так:
         * public static ObservableCollection<Student> SelectStudentsByID(int id) => new(from s in GetCollection<Student>() where s.GroupID == id select s);
         * но пожалуй не буду
         */
    }
    public static void UpdateEntity<T>(Entity entity)
    {
        using AppContext db = new();

        if (typeof(T) == typeof(Student))
            db.Students.Update((Student)entity);

        else if (typeof(T) == typeof(Discipline))
            db.Disciplines.Update((Discipline)entity);

        else if (typeof(T) == typeof(Group))
            db.Groups.Update((Group)entity);

        else if (typeof(T) == typeof(Teacher))
            db.Teachers.Update((Teacher)entity);

        db.SaveChanges();
    }

    public static void AddEntity<T>(Entity entity)
    {
        using AppContext db = new();

        if (typeof(T) == typeof(Student))
                db.Students.Add((Student)entity);

        else if (typeof(T) == typeof(Discipline))
                db.Disciplines.Add((Discipline)entity);

        else if (typeof(T) == typeof(Group))
                db.Groups.Add((Group)entity);

        else if (typeof(T) == typeof(Teacher))
                db.Teachers.Add((Teacher)entity);

        //db.SaveChanges();
    }
    
    public static void RemoveEntity<T>(Entity entity)
    {
        using AppContext db = new();

        if (typeof(T) == typeof(Student))
            db.Students.Remove((Student)entity);

        else if (typeof(T) == typeof(Discipline))
            db.Disciplines.Remove((Discipline)entity);

        else if (typeof(T) == typeof(Group))
            db.Groups.Remove((Group)entity);

        else if (typeof(T) == typeof(Teacher))
            db.Teachers.Remove((Teacher)entity);

        db.SaveChanges();
    }

    public static ObservableCollection<T> GetCollection<T>()
    {
        dynamic? collection = null;

        using (AppContext db = new())
        {
            if (typeof(T) == typeof(Student))
            {
                collection = new ObservableCollection<Student>(db.Students);
                foreach (Student student in collection)
                    student.Group = SelectGroupByID(student.GroupID);
            }

            else if (typeof(T) == typeof(Discipline))
                collection = new ObservableCollection<Discipline>(db.Disciplines);

            else if (typeof(T) == typeof(Group))
                collection = new ObservableCollection<Group>(db.Groups);

            else if (typeof(T) == typeof(Teacher))
                collection = new ObservableCollection<Teacher>(db.Teachers);
        }

        return collection!;
    }
}