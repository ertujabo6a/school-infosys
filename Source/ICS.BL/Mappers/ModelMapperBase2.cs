// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ICS.BL.Mappers.Interfaces;

namespace ICS.BL.Mappers;

public abstract class ModelMapperBase2<TEntity, TListModel> :
    IModelMapper2<TEntity, TListModel>
{
    //methods from IModelMapper2
    public abstract TListModel MapToListModel(TEntity? entity);
    public IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    public abstract TEntity MapToEntity(TListModel list_model);
}
