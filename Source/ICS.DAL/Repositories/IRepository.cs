// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Repositories;
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    public IQueryable<TEntity> Get();
    public Task DeleteAsync(Guid entityId);
    public ValueTask<bool> ExistsAsync(TEntity entity);
    public ValueTask<TEntity> InsertAsync(TEntity entity);
    public ValueTask<TEntity> UpdateAsync(TEntity entity);

    public async ValueTask<TEntity?> GetByIdAsync(Guid Id)
    {
        return await Get().SingleAsync(entity => entity.Id == Id);
    }
}
