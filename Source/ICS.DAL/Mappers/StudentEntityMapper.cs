using ICS.DAL.Entities;

namespace ICS.DAL.Mappers;

public class StudentEntityMapper : IEntityMapper<StudentEntity>
{
    public void Map(StudentEntity oldEntity, StudentEntity newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Surname = newEntity.Surname;
        oldEntity.ImageUrl = newEntity.ImageUrl;
    }
}
