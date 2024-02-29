using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ICS.DAL;
public class IcsDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();
    public DbSet<ActivityStudent> ActivitiesStudents => Set<ActivityStudent>();
    public DbSet<OneOffActivityDateEntity> OneOffActivityDates => Set<OneOffActivityDateEntity>();
    public DbSet<EvaluationEntity> EvaluationEntities => Set<EvaluationEntity>();
    public DbSet<OneOffActivityEntity> OneOffActivities => Set<OneOffActivityEntity>();
    public DbSet<PeriodicActivityEntity> PeriodicActivities => Set<PeriodicActivityEntity>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<SubjectTeacher> SubjectTeachers => Set<SubjectTeacher>();
    public DbSet<SubjectStudent> SubjectStudents => Set<SubjectStudent>();

}
