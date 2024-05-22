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
    private readonly ISubjectFacade _subjectFacadeSut;

    public SubjectFacadeTests(ITestOutputHelper output) : base(output)
    {
        _subjectFacadeSut = new SubjectFacade(UnitOfWorkFactory, SubjectModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new SubjectDetailModel()
        {
            Id = Guid.Empty,
            SubjectName = "Subject 1",
            SubjectAbbr = "SUB1",
            Credits = 5
        };

        var _ = await _subjectFacadeSut.SaveAsync(model);
    }

    [Fact]
    public async Task GetAll_Single_SeededSubject()
    {
        var subjects = await _subjectFacadeSut.GetAsync();
        var subject = subjects.Single(s => s.Id == SubjectSeeds.SubjectEntity_BL_SubjectTest_GetAll.Id);

        DeepAssert.Equal(SubjectModelMapper.MapToListModel(SubjectSeeds.SubjectEntity_BL_SubjectTest_GetAll), subject);
    }

    [Fact]
    public async Task GetById_NonExistent()
    {
        var subject = await _subjectFacadeSut.GetAsync(Guid.NewGuid());

        Assert.Null(subject);
    }

    [Fact]
    public async Task SeededSubject_DeleteById_Deleted()
    {
        await _subjectFacadeSut.DeleteAsync(SubjectSeeds.SubjectEntity_BL_SubjectTest_DeleteById.Id);

        var subject = await _subjectFacadeSut.GetAsync(SubjectSeeds.SubjectEntity_BL_SubjectTest_DeleteById.Id);
        Assert.Null(subject);
    }

    [Fact]
    public async Task Delete_SubjectUsedInActivity_DoesNotThrow()
    {
        //Act & Assert
        await _subjectFacadeSut.DeleteAsync(SubjectSeeds.SubjectEntity_BL_SubjectTest_Delete_SubjectUsedInActivity.Id);
    }

    [Fact]
    public async Task NewSubject_InsertOrUpdate_SubjectAdded()
    {
        //Arrange
        var subject = new SubjectDetailModel()
        {
            Id = Guid.Empty,
            SubjectName = "New Subject",
            SubjectAbbr = "NEW",
            Credits = 2
        };

        //Act
        subject = await _subjectFacadeSut.SaveAsync(subject);

        //Assert
        var subjectFromDb = await _subjectFacadeSut.GetAsync(subject.Id);
        DeepAssert.Equal(subject, subjectFromDb);
    }

    [Fact]
    public async Task SeededSubject_InsertOrUpdate_SubjectUpdated()
    {
        //Arrange
        var subject = new SubjectDetailModel()
        {
            Id = SubjectSeeds.SubjectEntity_BL_SubjectTest_Update.Id,
            SubjectName = SubjectSeeds.SubjectEntity_BL_SubjectTest_Update.Name,
            SubjectAbbr = SubjectSeeds.SubjectEntity_BL_SubjectTest_Update.Abbr,
            Credits = SubjectSeeds.SubjectEntity_BL_SubjectTest_Update.Credits
        };
        subject.SubjectName += " Updated";
        subject.SubjectAbbr += "U";

        //Act
        await _subjectFacadeSut.SaveAsync(subject);

        //Assert
        var subjectFromDb = await _subjectFacadeSut.GetAsync(SubjectSeeds.SubjectEntity_BL_SubjectTest_Update.Id);
        DeepAssert.Equal(subject, subjectFromDb);
    }
}
