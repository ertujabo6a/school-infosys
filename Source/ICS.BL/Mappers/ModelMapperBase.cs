using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public abstract class ModelMapperBase<TEntity, TListModel, TDetailModel> :
    IModelMapper<TEntity, TListModel, TDetailModel>
{
    //methods from IModeLMapper
    public abstract TListModel MapToListModel(TEntity? entity);
    public IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    public abstract TDetailModel MapToDetailModel(TEntity entity);
    public IEnumerable<TDetailModel> MapToDetailModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToDetailModel);

    public abstract TEntity MapToEntity(TDetailModel list_model);


}


