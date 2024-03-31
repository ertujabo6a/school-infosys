using ICS.DAL.Entities;

namespace ICS.DAL.Mappers;

public class EvaluationEntityMapper : IEntityMapper<EvaluationEntity>
{
    public void Map(EvaluationEntity oldEntity, EvaluationEntity newEntity)
    {
        oldEntity.Description = newEntity.Description;
        oldEntity.Points = newEntity.Points;
        oldEntity.ActivityId = newEntity.ActivityId;
    }
}
