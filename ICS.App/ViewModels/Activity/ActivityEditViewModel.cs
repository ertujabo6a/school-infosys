using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ICS.App.Messages;
using ICS.App.Services;
using ICS.BL.Facades.Interfaces;
using ICS.BL.Models;
using ICS.Common.Enums;

namespace ICS.App.ViewModels;

[QueryProperty(nameof(Activity), nameof(Activity))]
public partial class ActivityEditViewModel (
    IActivityFacade activityFacade,
    ISubjectFacade subjectFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public ActivityDetailModel Activity { get; init; } = ActivityDetailModel.Empty;
    public IList<SubjectListModel> Subjects { get; set; }
    [ObservableProperty]
    private SubjectListModel _selectedSubject;
    public IEnumerable<ActivityType> ActivityTypes { get; set; }
    [ObservableProperty]
    private ActivityType _selectedActivityType;
    public IEnumerable<Room> Rooms { get; set; }
    [ObservableProperty]
    private Room _selectedRoom;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Subjects = (await subjectFacade.GetAsync()).ToList();
        ActivityTypes = Enum.GetValues(typeof(ActivityType)).Cast<ActivityType>().ToList();
        Rooms = Enum.GetValues(typeof(Room)).Cast<Room>().ToList();
    }

    partial void OnSelectedSubjectChanged(SubjectListModel value)
    {
        Activity.SubjectId = value.Id;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await activityFacade.SaveAsync(Activity);
        MessengerService.Send(new ActivityEditMessage { ActivityId = Activity.Id });
        navigationService.SendBackButtonPressed();
    }
}
