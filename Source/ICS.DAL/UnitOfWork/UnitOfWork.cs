using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ICS.DAL.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IRepository<TEntity> GetRepository<TEntity, TEntityMapper>()
            where TEntity : class, IEntity
            where TEntityMapper : IEntityMapper<TEntity>, new()
        {
            return new Repository<TEntity>(_dbContext, new TEntityMapper());
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync().ConfigureAwait(false);
        }
    }
}

