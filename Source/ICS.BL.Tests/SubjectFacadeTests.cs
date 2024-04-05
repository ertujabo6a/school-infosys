using ICS.BL.Facades.Interfaces;
using ICS.BL.Facades;
using ICS.BL.Models;
using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.BL.Tests;

public sealed class SubjectFacadeTests : FacadeTestsBase
{
    private readonly ISubjectFacade _subjectFacadeSUT;

    public SubjectFacadeTests(ITestOutputHelper output) : base(output)
    {
        _subjectFacadeSUT = new SubjectFacade(UnitOfWorkFactory, SubjectModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new SubjectListModel()
        {
            Id = Guid.Empty,
            SubjectName = "Subject 1",
            SubjectAbbr = "SUB1",
            Credits = 5
        };

        var _ = await _subjectFacadeSUT.SaveAsync(model);
    }

    [Fact]
    public async Task GetAll_Single_SeededSubject()
    {
        var subjects = await _subjectFacadeSUT.GetAsync();
        var subject = subjects.Single(s => s.Id == SubjectSeeds.SubjectEntity.Id);

        DeepAssert.Equal(SubjectModelMapper.MapToListModel(SubjectSeeds.SubjectEntity), subject);
    }

    [Fact]
    public async Task GetById_NonExistent()
    {
        var subject = await _subjectFacadeSUT.GetAsync(Guid.NewGuid());

        Assert.Null(subject);
    }

    [Fact]
    public async Task SeededSubject_DeleteById_Deleted()
    {
        await _subjectFacadeSUT.DeleteAsync(SubjectSeeds.SubjectEntity.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Subjects.AnyAsync(s => s.Id == SubjectSeeds.SubjectEntity.Id));
    }

    [Fact]
    public async Task Delete_SubjectUsedInActivity_DoesNotThrow()
    {
        //Act & Assert
        await _subjectFacadeSUT.DeleteAsync(SubjectSeeds.SubjectEntity.Id);;
    }

    [Fact]
    public async Task NewSubject_InsertOrUpdate_SubjectAdded()
    {
        //Arrange
        var subject = new SubjectListModel()
        {
            Id = Guid.Empty,
            SubjectName = "New Subject",
            SubjectAbbr = "NEW",
            Credits = 2
        };

        //Act
        subject = await _subjectFacadeSUT.SaveAsync(subject);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var subjectFromDb = await dbxAssert.Subjects.SingleAsync(s => s.Id == subject.Id);
        DeepAssert.Equal(subject, SubjectModelMapper.MapToListModel(subjectFromDb));
    }

    [Fact]
    public async Task SeededSubject_InsertOrUpdate_SubjectUpdated()
    {
        //Arrange
        var subject = new SubjectListModel()
        {
            Id = SubjectSeeds.SubjectEntity.Id,
            SubjectName = SubjectSeeds.SubjectEntity.Name,
            SubjectAbbr = SubjectSeeds.SubjectEntity.Abbr,
            Credits = SubjectSeeds.SubjectEntity.Credits
        };
        subject.SubjectName += " Updated";
        subject.SubjectAbbr += "U";

        //Act
        await _subjectFacadeSUT.SaveAsync(subject);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var subjectFromDb = await dbxAssert.Subjects.SingleAsync(s => s.Id == subject.Id);
        DeepAssert.Equal(subject, SubjectModelMapper.MapToListModel(subjectFromDb));
    }
}
