namespace College_Data_Base.Core;

using College_Data_Base.MVVM.Model;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public AppContext() => Database.EnsureCreated();
    
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Discipline> Disciplines => Set<Discipline>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseMySql(ServerManager.ConnectionString, ServerVersion.AutoDetect(ServerManager.ConnectionString));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discipline>().HasOne(d => d.Teacher)
                                         .WithOne(t => t.Discipline)
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