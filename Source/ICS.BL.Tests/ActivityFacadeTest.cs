using ICS.BL.Facades;
using ICS.BL.Models;
using ICS.Common.Enums;
using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using System.Collections.ObjectModel;
using ICS.BL.Mappers;
using ICS.DAL;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using ICS.BL.Facades.Interfaces;

namespace ICS.BL.Tests;

public class ActivityFacadeTests : FacadeTestsBase
{
    private readonly IActivityFacade _activityFacadeSUT;

    public ActivityFacadeTests(ITestOutputHelper output) : base(output)
    {
        _activityFacadeSUT = new ActivityFacade(UnitOfWorkFactory, ActivityModelMapper);
    }

    [Fact]
    public async Task Add_NewActivity_Persisted()
    {
        // Arrange
        var activity = new ActivityDetailModel()
        {
            Id = Guid.Parse(input: "fab130cd-eefe-443f-baf6-3d96cc2cbf23"),
            SubjectAbbr = "ABR",
            Type = ActivityType.Lecture,
            ActivityRoom = Room.E112,
            StartDate = new DateTime(2024, 4, 1, 12, 0, 0),
            EndDate = new DateTime(2024, 5, 3, 13, 50, 0),
            Description = "Some fun activity",
            SubjectId = SubjectSeeds.SubjectEntity_ActivityTest_AddNew.Id
        };
        // Act
        var _activity = await _activityFacadeSUT.SaveAsync(activity);
        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        var activityFromDb = await dbContext.Activities.SingleAsync(e => e.Id == _activity.Id);
        DeepAssert.Equal(_activity, ActivityModelMapper.MapToDetailModel(activityFromDb));
    }

    [Fact]
    public async Task GetById()
    {

        //Act
        var activities = await _activityFacadeSUT.GetAsync();
        var activity = activities.Single(e => e.Id == ActivitySeeds.ActivityEntity_BL_ActivityTest_GetById.Id);
        //Assert
        DeepAssert.Equal(ActivityModelMapper.MapToListModel(ActivitySeeds.ActivityEntity_BL_ActivityTest_GetById), activity );
    }

    [Fact]
    public async Task GetById_NonExistent()
    {
        //Act
        var activity = await _activityFacadeSUT.GetAsync(Guid.NewGuid());
        //Assert
        Assert.Null(activity);
    }

    [Fact]
    public async Task DeleteById()
    {
        await _activityFacadeSUT.DeleteAsync(ActivitySeeds.ActivityEntity_BL_ActivityTest_DeleteById.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Activities.AnyAsync(e => e.Id == ActivitySeeds.ActivityEntity_BL_ActivityTest_DeleteById.Id));
    }

    [Fact]
    public async Task InsertById()
    {
        var activityListModel = new ActivityDetailModel()
        {
            Id = Guid.Parse(input: "fab130cd-eefe-443f-baf6-3d96cc2cbf23"),
            SubjectAbbr = "ABR",
            Type = ActivityType.Lecture,
            ActivityRoom = Room.E112,
            StartDate = new DateTime(2024, 4, 1, 12, 0, 0),
            EndDate = new DateTime(2024, 5, 3, 13, 50, 0),
            SubjectId = SubjectSeeds.SubjectEntity_BL_ActivityTest_Insert.Id
        };

        var model = await _activityFacadeSUT.SaveAsync(activityListModel);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var activity = await dbxAssert.Activities.SingleAsync(e => e.Id == model.Id);

        DeepAssert.Equal(model, ActivityModelMapper.MapToDetailModel(activity));
    }

}
