/*
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Messages;
using ICS.App.Services;
using ICS.BL.Facades;
using ICS.BL.Models;

namespace ICS.App.ViewModels.Activity;

public class ActivityListViewModel(
    ActivityFacade activityFacade,
    IMessengerService messengerService) : ViewModelBase(messengerService)
{
    public IEnumerable<ActivityListModel> Activities { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Activities = await activityFacade.GetAsync();
    }

}
*/
