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
        ISubjectFacade subjectFacade,
        INavigationService navigationService,
        IMessengerService messengerService)
        : ViewModelBase(messengerService), IRecipient<ActivityEditMessage>, IRecipient<ActivityDeleteMessage>
    {
        public IEnumerable<ActivityListModel> Activities { get; set; } = null!;
        private bool _isSortedDescending = false;

        protected override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();
            Activities = await activityFacade.GetAsync();
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

        [RelayCommand]
        private void SortBySubjectAbbr()
        {
            if (!_isSortedDescending)
            {
                Activities = Activities.OrderBy(e => e.SubjectAbbr);
                _isSortedDescending = true;
            }
            else
            {
                Activities = Activities.OrderByDescending(e => e.SubjectAbbr);
                _isSortedDescending = false;
            }
        }

        [RelayCommand]
        private void SortByType()
        {
            if (!_isSortedDescending)
            {
                Activities = Activities.OrderBy(e => e.Type);
                _isSortedDescending= true;
            }
            else
            {
                Activities = Activities.OrderByDescending(e => e.Type);
                _isSortedDescending = false;
            }
        }

        [RelayCommand]
        private void SortByStartTime()
        {
            if (!_isSortedDescending)
            {
                Activities = Activities.OrderBy(e => e.StartTime);
                _isSortedDescending = true;
            }
            else
            {
                Activities = Activities.OrderByDescending(e => e.StartTime);
                _isSortedDescending = false;
            }
        }

        [RelayCommand]
        private void SortByEndTime()
        {
            if (!_isSortedDescending)
            {
                Activities = Activities.OrderBy(e => e.EndTime);
                _isSortedDescending= true;
            }
            else
            {
                Activities = Activities.OrderByDescending(e => e.EndTime);
                _isSortedDescending = false;
            }
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

