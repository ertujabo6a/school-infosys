// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.DAL.Entities;

namespace ICS.DAL.Mappers;

public interface IEntityMapper<in TEntity> where TEntity : IEntityMapper
{
    void Map(TEntity oldEntity, TEntity newEntity);
}
