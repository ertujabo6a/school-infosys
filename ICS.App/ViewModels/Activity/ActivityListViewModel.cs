using System.Diagnostics;
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
        ISubjectFacade subjectFacade,
        INavigationService navigationService,
        IMessengerService messengerService)
        : ViewModelBase(messengerService), IRecipient<ActivityEditMessage>, IRecipient<ActivityDeleteMessage>, IRecipient<SubjectDeleteMessage>, IRecipient<SubjectEditMessage>
    {
        public IEnumerable<ActivityListModel> Activities { get; set; } = null!;
        private bool _isSortedDescending = false;
        public IList<SubjectListModel>? Subjects { get; set; }

        [ObservableProperty]
        private SubjectListModel? _selectedSubject;

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
            Activities = (await activityFacade.GetAsync()).ToList();
            foreach (ActivityListModel e in Activities)
            {
                SubjectDetailModel? subjectDetailModel = await subjectFacade.GetAsync(e.SubjectId);
                if (subjectDetailModel != null)
                {
                    e.SubjectAbbr = subjectDetailModel.SubjectAbbr;
                }
            }

            Subjects = (await subjectFacade.GetAsync()).ToList();
        }

        [RelayCommand]
        private async Task GoToCreateAsync()
        {
            await navigationService.GoToAsync("/edit");
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

        [RelayCommand]
        private async Task Filter()
        {
            Activities = (await activityFacade.GetAsync(SelectedSubject == null ? null : SelectedSubject.SubjectAbbr, StartDate.Date + StartTime, EndDate.Date + EndTime)).ToList();
            foreach (ActivityListModel e in Activities)
            {
                SubjectDetailModel? subjectDetailModel = await subjectFacade.GetAsync(e.SubjectId);
                if (subjectDetailModel != null)
                {
                    e.SubjectAbbr = subjectDetailModel.SubjectAbbr;
                }
            }
            Activities = Activities.ToList();
        }

        [RelayCommand]
        private async Task Unfilter()
        {
            Activities = (await activityFacade.GetAsync()).ToList();
            foreach (ActivityListModel e in Activities)
            {
                SubjectDetailModel? subjectDetailModel = await subjectFacade.GetAsync(e.SubjectId);
                if (subjectDetailModel != null)
                {
                    e.SubjectAbbr = subjectDetailModel.SubjectAbbr;
                }
            }
            Activities = Activities.ToList();
            SelectedSubject = null;
        }

        public async void Receive(ActivityEditMessage message)
        {
            await LoadDataAsync();
        }

        public async void Receive(ActivityDeleteMessage message)
        {
            await LoadDataAsync();
        }

        public async void Receive(SubjectDeleteMessage message)
        {
            await LoadDataAsync();
        }

        public async void Receive(SubjectEditMessage message)
        {
            await LoadDataAsync();
            Subjects = (await subjectFacade.GetAsync()).ToList();
        }
    }
}

