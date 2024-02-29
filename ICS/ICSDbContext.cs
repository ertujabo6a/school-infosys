using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ICS.DAL;
public sealed class IcsDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Admin> Admins => Set<Admin>();

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
    }
}
