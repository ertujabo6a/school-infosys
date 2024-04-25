using CookBook.BL.Facades;
using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ICS.BL.Facades;

public class StudentFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IStudentModelMapper modelMapper)
    : FacadeBase<StudentEntity, StudentListModel, StudentDetailModel, StudentEntityMapper>(unitOfWorkFactory,
        modelMapper), IStudentFacade
{
    public async Task<IEnumerable<StudentListModel>> GetAsync(string? name, string? surname, string? orderBy)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        List<StudentEntity> students = await uow
                .GetRepository<StudentEntity, StudentEntityMapper>()
                .Get()
                .Where(i => i.Name == (!string.IsNullOrEmpty(name) ? name : i.Name) && i.Surname == (!string.IsNullOrEmpty(surname) ? surname : i.Surname))
                .ToListAsync().ConfigureAwait(false);

        if (!string.IsNullOrEmpty(orderBy))
            switch (orderBy.ToLower())
            {   
                case "name":
                    students = (List<StudentEntity>)students.OrderBy(i => i.Name);
                    break;
                case "surname":
                    students = (List<StudentEntity>)students.OrderBy(i => i.Surname);
                    break;
            }

        return ModelMapper.MapToListModel(students);
    }

    protected override ICollection<string> IncludesNavigationPathDetail =>
        [$"{nameof(StudentEntity.Subjects)}"];
}
