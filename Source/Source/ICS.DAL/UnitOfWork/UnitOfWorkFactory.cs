using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.UnitOfWork;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IDbContextFactory<IcsDbContext> _dbContextFactory;

    public UnitOfWorkFactory(IDbContextFactory<IcsDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
    }

    public IUnitOfWork Create()
    {
        return new UnitOfWork(_dbContextFactory.CreateDbContext());
    }
}
