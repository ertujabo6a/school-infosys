using ICS.BL.Mappers;
using ICS.Common.Tests;
using ICS.Common.Tests.Factories;
using ICS.DAL;
using ICS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.BL.Tests;

public class FacadeTestsBase : IAsyncLifetime
{
    protected IDbContextFactory<IcsDbContext> DbContextFactory { get; }

    protected ActivityModelMapper ActivityModelMapper { get; }
    protected EvaluationModelMapper EvaluationModelMapper { get; }
    protected StudentModelMapper StudentModelMapper { get; }
    protected SubjectModelMapper SubjectModelMapper { get; }

    protected UnitOfWorkFactory UnitOfWorkFactory { get; }

    protected FacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);

        ActivityModelMapper = new ActivityModelMapper();
        EvaluationModelMapper = new EvaluationModelMapper();
        SubjectModelMapper = new SubjectModelMapper();
        StudentModelMapper = new StudentModelMapper(SubjectModelMapper);

        UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);
    }

    public async Task InitializeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
        await dbx.Database.EnsureCreatedAsync();
    }
    public async Task DisposeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
    }
}
