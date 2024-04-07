using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL;
public class IcsDbContext(DbContextOptions contextOptions) : DbContext(contextOptions)
{
    public DbSet<StudentEntity> Students => Set<StudentEntity>();
    public DbSet<SubjectEntity> Subjects => Set<SubjectEntity>();
    public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();
    public DbSet<EvaluationEntity> Evaluations => Set<EvaluationEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ActivityEntity>()
            .HasOne(i => i.Subject)
            .WithMany(i => i.Activities)
            .HasForeignKey(i => i.SubjectId);

        modelBuilder.Entity<EvaluationEntity>()
            .HasOne(i => i.Activity)
            .WithMany(i => i.Evaluations)
            .HasForeignKey(i => i.ActivityId);

        modelBuilder.Entity<EvaluationEntity>()
            .HasOne(i => i.Student)
            .WithMany(i => i.Evaluations)
            .HasForeignKey(i => i.StudentId);

        modelBuilder.Entity<SubjectEntity>()
            .HasMany(i => i.Students)
            .WithMany(i => i.Subjects);
    }
}
