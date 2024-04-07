using ICS.BL.Facades.Interfaces;
using ICS.BL.Facades;
using ICS.BL.Models;
using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using ICS.DAL.Entities;
using System.Collections.ObjectModel;

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
        StudentReferenceModel? student = await _studentFacade.GetAsync(StudentSeeds.EmptyStudentEntity.Id);

        Assert.Null(student);
    }

    [Fact]
    public async Task GetAsync_Student_SampleById()
    {
        StudentReferenceModel? student = await _studentFacade.GetAsync(StudentSeeds.StudentEntity.Id);

        Assert.NotNull(student);
        Assert.Equal(StudentSeeds.StudentEntity.Id, student.Id);
    }

    [Fact]
    public async Task GetAll_Single_SeededStudent()
    {
        var students = await _studentFacade.GetAsync();
        var student = students.Single(s => s.Id == StudentSeeds.StudentEntity.Id);

        DeepAssert.Equal(StudentModelMapper.MapToListModel(StudentSeeds.StudentEntity), student);
    }

    [Fact]
    public async Task Delete_Student_SampleDataDeleted()
    {
        await _studentFacade.DeleteAsync(StudentSeeds.StudentEntity.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Students.AnyAsync(s => s.Id == StudentSeeds.StudentEntity.Id));
    }

    [Fact]
    public async Task SaveAsync_InsertOrUpdate_NewStudent()
    {
        //Arrange
        var student = new StudentListModel()
        {
            Id = Guid.Empty,
            Name = "New Name",
            Surname = "New Surname",
        };

        //Act
        student = await _studentFacade.SaveAsync(student);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        StudentEntity? studentFromDb = await dbxAssert.Students.SingleAsync(s => s.Id == student.Id);
        DeepAssert.Equal(student, StudentModelMapper.MapToListModel(studentFromDb));
    }

    [Fact]
    public async Task SaveAsync_InsertOrUpdate_StudentUpdated()
    {
        //Arrange
        var student = new StudentListModel()
        {
            Id = StudentSeeds.StudentEntity.Id,
            Name = StudentSeeds.StudentEntity.Name,
            Surname = StudentSeeds.StudentEntity.Surname,
        };
        student.Name += " Updated";
        student.Surname += " Updated";

        //Act
        await _studentFacade.SaveAsync(student);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        StudentEntity studentFromDb = await dbxAssert.Students.SingleAsync(s => s.Id == student.Id);
        DeepAssert.Equal(student, StudentModelMapper.MapToListModel(studentFromDb));
    }

    [Fact]
    public async Task SaveAsync_UpdateWithSideColl()
    {
        var student = new StudentListModel()
        {
            Id =StudentSeeds.StudentEntity.Id,
            Name = StudentSeeds.StudentEntity.Name,
            Surname = StudentSeeds.StudentEntity.Surname,
            Subjects = 
            {
                new()
                {
                    SubjectAbbr = SubjectSeeds.SubjectEntity.Abbr
                }
            }
            
        };
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _studentFacade.SaveAsync(student));
    }
}
