using ICS.DAL.Entities;

namespace ICS.DAL.Mappers;

public class StudentToSubjectEntityMapper : IEntityMapper<StudentToSubjectEntity>
{
    public void Map(StudentToSubjectEntity oldEntity, StudentToSubjectEntity newEntity)
    {
        oldEntity.StudentId = newEntity.StudentId;
        oldEntity.SubjectId = newEntity.SubjectId;
    }
}
