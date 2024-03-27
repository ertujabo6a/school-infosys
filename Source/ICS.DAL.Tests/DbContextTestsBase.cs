using ICS.Common.Tests;
using ICS.Common.Tests.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.DAL.Tests;

public class DbContextTestsBase : IAsyncLifetime
{
    protected DbContextTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);
        IcsDbContextSut = DbContextFactory.CreateDbContext();
    }

    protected IDbContextFactory<IcsDbContext> DbContextFactory { get; }
    protected IcsDbContext IcsDbContextSut { get; }

    public async Task InitializeAsync()
    {
        await IcsDbContextSut.Database.EnsureDeletedAsync();
        await IcsDbContextSut.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await IcsDbContextSut.Database.EnsureDeletedAsync();
        await IcsDbContextSut.DisposeAsync();
    }
}
