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
    public IList<SubjectListModel>? Subjects { get; set; }
    [ObservableProperty]
    private SubjectListModel _selectedSubject = null!;
    public IEnumerable<ActivityType>? ActivityTypes { get; set; }
    [ObservableProperty]
    private ActivityType _selectedActivityType;
    public IEnumerable<Room>? Rooms { get; set; }

    [ObservableProperty]
    private Room _selectedRoom;

    [ObservableProperty]
    private DateTime _startDate = DateTime.Now;

    [ObservableProperty]
    private TimeSpan _startTime = TimeSpan.Zero;

    [ObservableProperty]
    private DateTime _endDate = DateTime.Now;

    [ObservableProperty]
    private TimeSpan _endTime = TimeSpan.Zero;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Subjects = (await subjectFacade.GetAsync()).ToList();
        ActivityTypes = Enum.GetValues(typeof(ActivityType)).Cast<ActivityType>().ToList();
        Rooms = Enum.GetValues(typeof(Room)).Cast<Room>().ToList();
        StartDate = Activity.StartTime.Date;
        StartTime = new TimeSpan(Activity.StartTime.Hour, Activity.StartTime.Minute, Activity.StartTime.Second);
        EndDate = Activity.EndTime.Date;
        EndTime = new TimeSpan(Activity.EndTime.Hour, Activity.EndTime.Minute, Activity.EndTime.Second);
    }

    partial void OnSelectedSubjectChanged(SubjectListModel value)
    {
        Activity.SubjectId = value.Id;
    }

    partial void OnSelectedActivityTypeChanged(ActivityType value)
    {
        Activity.Type = value;
    }

    partial void OnSelectedRoomChanged(Room value)
    {
        Activity.ActivityRoom = value;
    }


    [RelayCommand]
    private async Task SaveAsync()
    {
        Activity.StartTime = StartDate.Date + StartTime;
        Activity.EndTime = EndDate.Date + EndTime;

        await activityFacade.SaveAsync(Activity);
        MessengerService.Send(new ActivityEditMessage { ActivityId = Activity.Id });
        navigationService.SendBackButtonPressed();
    }
}
