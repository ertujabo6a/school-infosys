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
public class Repository<TEntity> where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _entities;
    private readonly IEntityMapper<TEntity> _mapper; // TODO: integrate mappers, as they be implemented

    protected Repository(DbSet<TEntity> entities, IEntityMapper<TEntity> mapper)
    {
        _entities = entities;
        _mapper = mapper;
    }
}
