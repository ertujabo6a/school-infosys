using ICS.DAL.Factories;
using ICS.DAL.Mappers;
using ICS.DAL.Migrator;
using ICS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ICS.DAL;

public static class DALInstaller
{
    public static IServiceCollection AddDALServices(this IServiceCollection services, DALOptions options)
    {
        services.AddSingleton(options);
        services.AddSingleton<IDbContextFactory<IcsDbContext>>(_ =>
            new DbContextSqLiteFactory(options.DatabaseFilePath, options?.SeedDemoData ?? false));
        services.AddSingleton<IDbMigrator, DbMigrator>();

        services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
        services.AddSingleton<IDbContextFactory<IcsDbContext>, DbContextSqLiteFactory>(_ => new DbContextSqLiteFactory(options.DatabaseFilePath, options.SeedDemoData));

        services.AddSingleton<ActivityEntityMapper>();
        services.AddSingleton<EvaluationEntityMapper>();
        services.AddSingleton<StudentEntityMapper>();
        services.AddSingleton<SubjectEntityMapper>();
        services.AddSingleton<StudentToSubjectEntityMapper>();

        return services;
    }
}
