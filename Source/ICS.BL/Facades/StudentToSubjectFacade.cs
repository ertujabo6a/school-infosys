using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.Repositories;
using ICS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ICS.BL.Facades;

public class StudentToSubjectFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IStudentToSubjectModelMapper modelMapper)
    : FacadeBase<StudentToSubjectEntity, StudentToSubjectModel, StudentToSubjectModel, StudentToSubjectEntityMapper>(unitOfWorkFactory,
        modelMapper), IStudentToSubjectFacade
{
    IStudentToSubjectModelMapper _modelMapper = modelMapper;
    public async Task<IEnumerable<StudentToSubjectModel>> GetAsync(Guid? studentId)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        List<StudentToSubjectEntity> studentToSubjects = await uow
            .GetRepository<StudentToSubjectEntity, StudentToSubjectEntityMapper>()
            .Get()
            .Where(i => i.StudentId == (studentId != null ? studentId : i.StudentId))
            .ToListAsync().ConfigureAwait(false);
        return ModelMapper.MapToListModel(studentToSubjects);
    }

    public async Task SaveAsync(StudentDetailModel student)
    {
        var studentToSubjects = await GetAsync(student.Id);
        foreach (var item in studentToSubjects)
            await DeleteAsync(item.Id);

        foreach (var item in student.Subjects)
        {
            var studToSubModel = _modelMapper.MapToModel(student, item);

            var entity = ModelMapper.MapToEntity(studToSubModel);
            await using IUnitOfWork uow = UnitOfWorkFactory.Create();
            IRepository<StudentToSubjectEntity> repository = uow.GetRepository<StudentToSubjectEntity, StudentToSubjectEntityMapper>();
            entity.Id = Guid.NewGuid();
            var insertedEntity = await repository.InsertAsync(entity);
            await uow.CommitAsync().ConfigureAwait(false);
        }
    }
}
