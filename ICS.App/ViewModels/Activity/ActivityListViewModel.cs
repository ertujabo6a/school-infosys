using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Messages;
using ICS.App.Services;
using ICS.BL.Facades.Interfaces;
using ICS.BL.Models;

namespace ICS.App.ViewModels
{
    public partial class ActivityListViewModel(
        IActivityFacade activityFacade,
        INavigationService navigationService,
        IMessengerService messengerService)
        : ViewModelBase(messengerService), IRecipient<ActivityEditMessage>, IRecipient<ActivityDeleteMessage>
    {
        public IEnumerable<ActivityListModel> Activities { get; set; } = null!;
        private ObservableCollection<ActivityListModel> FilteredActivities { get; set; } = [];

        [ObservableProperty]
        private TimeSpan startTime = TimeSpan.Zero;

        [ObservableProperty]
        private TimeSpan endTime = TimeSpan.Zero;

        protected override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();

            Activities = await activityFacade.GetAsync();
            // Initialize FilteredActivities with all activities initially
            FilteredActivities.Clear();
            foreach (var activity in Activities)
            {
                FilteredActivities.Add(activity);
            }
        }

        private async Task Filter(DateTime start, DateTime end)
        {
            var filteredActivities = await activityFacade.GetAsync(null, start, end);
            FilteredActivities.Clear();
            foreach (var activity in filteredActivities)
            {
                FilteredActivities.Add(activity);
            }
        }

        [RelayCommand]
        private async Task FilterByTimeAsync()
        {
            DateTime startDate = DateTime.Today.Add(StartTime);
            DateTime endDate = DateTime.Today.Add(EndTime);
            await Filter(startDate, endDate);
        }

        [RelayCommand]
        private async Task GoToCreateAsync()
        {
            await navigationService.GoToAsync("//activities/edit");
        }

        [RelayCommand]
        private async Task GoToDetailAsync(Guid id)
        {
            await navigationService.GoToAsync<ActivityDetailViewModel>(
                new Dictionary<string, object?> { [nameof(ActivityDetailViewModel.Id)] = id });
        }

        public async void Receive(ActivityEditMessage message)
        {
            await LoadDataAsync();
        }

        public async void Receive(ActivityDeleteMessage message)
        {
            await LoadDataAsync();
        }
    }
}

