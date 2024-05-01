namespace ICS.BL.Mappers.Interfaces;

public interface IModelMapper<TEntity, TListModel, TDetailModel>
{
    TListModel MapToListModel(TEntity? entity);

    //Maps a collection of Entities to a collection of ListModels
    IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    TDetailModel MapToDetailModel(TEntity entity);
    //Maps a collection of Entities to a collection of ListModels
    IEnumerable<TDetailModel> MapToDetailModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToDetailModel);

    TEntity MapToEntity(TDetailModel detailModel);
}
