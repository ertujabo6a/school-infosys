using ICS.DAL.Entities;
using ICS.DAL.Seeds;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL;
public class IcsDbContext(DbContextOptions contextOptions, bool seedDemoData = false) : DbContext(contextOptions)
{
    public DbSet<StudentEntity> Students => Set<StudentEntity>();
    public DbSet<SubjectEntity> Subjects => Set<SubjectEntity>();
    public DbSet<StudentToSubjectEntity> studentToSubjects => Set<StudentToSubjectEntity>();
    public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();
    public DbSet<EvaluationEntity> Evaluations => Set<EvaluationEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentEntity>()
            .HasMany(i => i.StudentToSubjects)
            .WithOne(i => i.Student);

        modelBuilder.Entity<StudentEntity>()
            .HasMany(i => i.Evaluations)
            .WithOne(i => i.Student);

        modelBuilder.Entity<SubjectEntity>()
            .HasMany(i => i.StudentToSubjects)
            .WithOne(i => i.Subject);

        modelBuilder.Entity<ActivityEntity>()
            .HasOne(i => i.Subject)
            .WithMany(i => i.Activities);

        modelBuilder.Entity<ActivityEntity>()
            .HasMany(i => i.Evaluations)
            .WithOne(i => i.Activity);

        if (seedDemoData)
        {
            StudentToSubjectSeeds.Seed(modelBuilder);
            StudentSeeds.Seed(modelBuilder);
            SubjectSeeds.Seed(modelBuilder);
            ActivitySeeds.Seed(modelBuilder);
            EvaluationSeeds.Seed(modelBuilder);
        }
    }
}
