using ICS.DAL.Entities;

namespace ICS.DAL.Mappers

public class ActivityEntityMapper : IEntityMapper<SubjectEntity>
{
    public void Map(SubjectEntity oldEntity, SubjectEntity newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Abbr = newEntity.Abbr;
        oldEntity.Credits = newEntity.Credits;
        oldEntity.EndTime = newEntity.EndTime;
        oldEntity.Description = newEntity.Description;
        oldEntity.Subject = newEntity.Subject;
        oldEntity.SubjectId = newEntity.SubjectId;
    }
}
