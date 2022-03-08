namespace College_Data_Base.Core.Managers;

using College_Data_Base.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;

public static class DataManager
{
    public static Teacher SelectCuratorByGroup(Group group)
    {
        ObservableCollection<Teacher> collection;

        using (AppContext db = new())
        {
            collection = new(db.Teachers);
        }

        var curator = (from c in collection where c.ID == @group.CuratorID select c).FirstOrDefault();

        return curator!;
    }

    public static ObservableCollection<Teacher> SelectTeachersByDiscipline(Discipline discipline)
    {
        ObservableCollection<Teacher> collection;

        using (AppContext db = new())
        {
            collection = new(db.Teachers);
        }

        var teachers = from t in collection where t.DisciplineID == discipline.ID select t;

        return new ObservableCollection<Teacher>(teachers);
    }

    public static ObservableCollection<Teacher> SelectAvailableCurators()
    {
        ObservableCollection<Teacher> collection;

        using (AppContext db = new())
        {
            collection = new(db.Teachers);
        }

        var curators = from c in collection where c.SupervisedGroup is null select c;

        return new ObservableCollection<Teacher>(curators);
    }

    public static Group SelectGroupByID(int? id)
    {
        ObservableCollection<Group> collection;

        using (AppContext db = new())
        {
            collection = new(db.Groups);
        }

        var group = (from g in collection where g.ID == id select g).FirstOrDefault();

        return group!;
    }

    public static ObservableCollection<Student> SelectStudentsByGroup(Group group)
    {
        ObservableCollection<Student> collection;

        using (AppContext db = new())
        {
            collection = new(db.Students);
        }

        var students = from s in collection where s.GroupID == @group.ID select s;

        return new ObservableCollection<Student>(students);
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
            {
                collection = new ObservableCollection<Group>(db.Groups);
                foreach (Group group in collection)
                    group.Curator = SelectCuratorByGroup(group);
            }

            else if (typeof(T) == typeof(Teacher))
                collection = new ObservableCollection<Teacher>(db.Teachers);            
        }

        return collection!;
    }
}