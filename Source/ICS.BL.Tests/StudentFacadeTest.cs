using ICS.BL.Facades.Interfaces;
using ICS.BL.Facades;
using ICS.BL.Models;
using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using ICS.DAL.Entities;

namespace ICS.BL.Tests;

public sealed class StudentFacadeTests : FacadeTestsBase
{
    private readonly IStudentFacade _studentFacade;

    public StudentFacadeTests(ITestOutputHelper output) : base(output)
    {
        _studentFacade = new StudentFacade(UnitOfWorkFactory, StudentModelMapper);
    }

    [Fact]
    public async Task GetAsync_Student_NonExistent()
    {
        var student = await _studentFacade.GetAsync(Guid.NewGuid());

        Assert.Null(student);
    }

    [Fact]
    public async Task GetAsync_Student_SampleById()
    {
        var student = await _studentFacade.GetAsync(StudentSeeds.StudentEntity_BL_StudentTest_GetById.Id);

        Assert.NotNull(student);
        Assert.Equal(StudentSeeds.StudentEntity_BL_StudentTest_GetById.Id, student.Id);
    }

    [Fact]
    public async Task GetAll_Single_SeededStudent()
    {
        var students = await _studentFacade.GetAsync();
        var student = students.Single(s => s.Id == StudentSeeds.StudentEntity_BL_StudentTest_GetAll.Id);

        DeepAssert.Equal(StudentModelMapper.MapToListModel(StudentSeeds.StudentEntity_BL_StudentTest_GetAll), student);
    }

    [Fact]
    public async Task Delete_Student_SampleDataDeleted()
    {
        await _studentFacade.DeleteAsync(StudentSeeds.StudentEntity_BL_StudentTest_Delete.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Students.AnyAsync(s => s.Id == StudentSeeds.StudentEntity_BL_StudentTest_Delete.Id));
    }

    [Fact]
    public async Task SaveAsync_InsertOrUpdate_NewStudent()
    {
        //Arrange
        var student = new StudentDetailModel()
        {
            Id = Guid.NewGuid(),
            Name = "New Name",
            Surname = "New Surname",
        };

        //Act
        student = await _studentFacade.SaveAsync(student);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var studentFromDb = await dbxAssert.Students.SingleAsync(s => s.Id == student.Id);
        DeepAssert.Equal(student, StudentModelMapper.MapToDetailModel(studentFromDb));
    }

    [Fact]
    public async Task SaveAsync_InsertOrUpdate_StudentUpdated()
    {
        //Arrange
        var student = new StudentDetailModel()
        {
            Id = StudentSeeds.StudentEntity_BL_StudentTest_Update.Id,
            Name = StudentSeeds.StudentEntity_BL_StudentTest_Update.Name,
            Surname = StudentSeeds.StudentEntity_BL_StudentTest_Update.Surname,
        };
        student.Name += " Updated";
        student.Surname += " Updated";

        //Act
        await _studentFacade.SaveAsync(student);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        StudentEntity studentFromDb = await dbxAssert.Students.SingleAsync(s => s.Id == student.Id);
        DeepAssert.Equal(student, StudentModelMapper.MapToDetailModel(studentFromDb));
    }

    [Fact]
    public async Task SaveAsync_UpdateWithSideColl()
    {
        var student = new StudentDetailModel()
        {
            Id =StudentSeeds.StudentEntity_BL_StudentTest_UpdateWithSideColl.Id,
            Name = StudentSeeds.StudentEntity_BL_StudentTest_UpdateWithSideColl.Name,
            Surname = StudentSeeds.StudentEntity_BL_StudentTest_UpdateWithSideColl.Surname,
            Subjects =
            {
                new()
                {
                    SubjectAbbr = SubjectSeeds.SubjectEntity_BL_StudentTest_UpdateWithSideColl.Abbr
                }
            }

        };
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _studentFacade.SaveAsync(student));
    }
}
