using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL;
public sealed class IcsDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();
    public DbSet<OneOffActivityEntity> OneOffActivities => Set<OneOffActivityEntity>();
    public DbSet<PeriodicActivityEntity> PeriodicActivities => Set<PeriodicActivityEntity>();
    public DbSet<PeriodicActivityDateEntity> PeriodicActivityDates => Set<PeriodicActivityDateEntity>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<EvaluationEntity> Evaluations => Set<EvaluationEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        string path = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.db");
        optionsBuilder.UseSqlite($"Data Source={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasKey(u => u.Login);

        modelBuilder.Entity<Student>().HasKey(u => u.UserLogin);
        modelBuilder.Entity<Student>()
            .HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<Student>(s => s.UserLogin)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Teacher>().HasKey(u => u.UserLogin);
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.User)
            .WithOne(u => u.Teacher)
            .HasForeignKey<Teacher>(s => s.UserLogin)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Admin>().HasKey(u => u.UserLogin);
        modelBuilder.Entity<Admin>()
            .HasOne(a => a.User)
            .WithOne(u => u.Admin)
            .HasForeignKey<Admin>(s => s.UserLogin)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Subject>().HasKey(s => s.Abbr);

        modelBuilder.Entity<ActivityEntity>().HasKey(a => a.EntityId);
        modelBuilder.Entity<ActivityEntity>()
            .HasOne(a => a.Subject)
            .WithMany(s => s.Activities)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Student>()
            .HasMany(a => a.Activities)
            .WithMany(s => s.Students);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.Subjects)
            .WithMany(s => s.Students);

        modelBuilder.Entity<Teacher>()
            .HasMany(s => s.Subjects)
            .WithMany(t => t.Teachers);

        modelBuilder.Entity<Teacher>()
            .HasMany(a => a.Activities)
            .WithOne(t => t.Teacher)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OneOffActivityEntity>().HasKey(a => a.ActivityId);
        modelBuilder.Entity<OneOffActivityEntity>()
            .HasOne(a => a.Activity)
            .WithOne(o => o.OneOff)
            .HasForeignKey<ActivityEntity>(o => o.EntityId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PeriodicActivityEntity>().HasKey(a => a.ActivityId);
        modelBuilder.Entity<PeriodicActivityEntity>()
            .HasOne(a => a.Activity)
            .WithOne(p => p.Periodic)
            .HasForeignKey<ActivityEntity>(p => p.EntityId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PeriodicActivityDateEntity>().HasKey(a => a.ActivityId);
        modelBuilder.Entity<PeriodicActivityDateEntity>()
            .HasOne(a => a.PeriodicActivity)
            .WithMany(p => p.ActivityDates);

        modelBuilder.Entity<Room>().HasKey(r => r.RoomName);
        modelBuilder.Entity<ActivityEntity>()
            .HasOne(r => r.Room)
            .WithMany(a => a.Activities)
            .HasForeignKey(r => r.RoomName)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<EvaluationEntity>().HasKey(s => s.StudentId);
        modelBuilder.Entity<EvaluationEntity>()
            .HasOne(s => s.Student)
            .WithMany(e => e.Evaluations);

        modelBuilder.Entity<EvaluationEntity>().HasKey(a => a.ActivityId);
        modelBuilder.Entity<EvaluationEntity>()
            .HasOne(a => a.Activity)
            .WithMany(e => e.Evaluations);
    }
}
