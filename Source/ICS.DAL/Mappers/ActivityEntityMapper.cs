using ICS.DAL.Entities;

namespace ICS.DAL.Mappers;

public class ActivityEntityMapper : IEntityMapper<ActivityEntity>
{
    public void Map(ActivityEntity oldEntity, ActivityEntity newEntity)
    {
        oldEntity.Type = newEntity.Type;
        oldEntity.Room = newEntity.Room;
        oldEntity.StartTime = newEntity.StartTime;
        oldEntity.EndTime = newEntity.EndTime;
        oldEntity.Description = newEntity.Description;
    }
}
