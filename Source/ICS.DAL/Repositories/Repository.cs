// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Repositories;
public class Repository<TEntity>(DbContext context,
    IEntityMapper<TEntity> entityMapper)
    : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public IQueryable<TEntity> Get() => _dbSet;
    public async ValueTask<bool> ExistsAsync(TEntity entity)
        => entity.Id != Guid.Empty
            && await _dbSet.AnyAsync(e  => e.Id == entity.Id).ConfigureAwait(false);

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
        => (await _dbSet.AddAsync(entity)).Entity;

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        TEntity existingEntity = await _dbSet.SingleAsync(e => e.Id == entity.Id).ConfigureAwait(false);
        entityMapper.MapToExistingEntity(existingEntity, entity); // TODO: integrate with mapper, as it be implemented
        return existingEntity;
    }

    public async Task DeleteAsync(Guid entityId)
        => _dbSet.Remove(await  _dbSet.SingleAsync(e => e.Id == entityId ).ConfigureAwait(false));

}
