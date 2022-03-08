namespace College_Data_Base.Core.Managers;

using College_Data_Base.MVVM.Model;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public AppContext() => Database.EnsureCreated();

    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Discipline> Disciplines => Set<Discipline>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (ServerManager.IsOffline)
            optionsBuilder.UseSqlite(ServerManager.ConnectionString!);
        else
            optionsBuilder.UseMySql(ServerManager.ConnectionString, ServerVersion.AutoDetect(ServerManager.ConnectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discipline>().HasMany(d => d.Teachers)
                                         .WithOne(t => t.Discipline)
                                         .HasForeignKey(t => t.DisciplineID)
                                         .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Student>().HasOne(s => s.Group)
                                      .WithMany(g => g.Students)
                                      .HasForeignKey(s => s.GroupID)
                                      .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Teacher>();

        modelBuilder.Entity<Group>().HasOne(g => g.Curator)
                                    .WithOne(c => c.SupervisedGroup)
                                    .OnDelete(DeleteBehavior.SetNull);
    }
}