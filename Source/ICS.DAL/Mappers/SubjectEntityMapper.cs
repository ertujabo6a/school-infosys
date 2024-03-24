using ICS.DAL.Entities;

namespace ICS.DAL.Mappers;

public class SubjectEntityMapper : IEntityMapper<SubjectEntity>
{
    public void Map(SubjectEntity oldEntity, SubjectEntity newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Abbr = newEntity.Abbr;
        oldEntity.Credits = newEntity.Credits;
    }
}
