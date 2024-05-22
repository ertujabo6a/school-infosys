using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;
using ICS.Common.Tests.Seeds;


namespace ICS.App.ViewModels;

public partial class EvaluationListViewModel(
    IEvaluationFacade evaluationFacade,
    IActivityFacade activityFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<EvaluationEditMessage>, IRecipient<EvaluationDeleteMessage>, IRecipient<SubjectDeleteMessage>, IRecipient<ActivityDeleteMessage>
{
    public IEnumerable<EvaluationListModel> Evaluations { get; set; } = null!;
    private bool _isSortedDescending = false;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Evaluations = (await evaluationFacade.GetAsync(null)).ToList();
        foreach (EvaluationListModel e in Evaluations)
        {
            ActivityDetailModel? activityDetailModel = await activityFacade.GetAsync(e.ActivityId);
            if (activityDetailModel != null)
            {
                e.SubjectAbbr = activityDetailModel.SubjectAbbr;
            }
        }
        Evaluations = Evaluations.ToList();
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/create",
            new Dictionary<string, object?> { [nameof(EvaluationEditViewModel.Evaluation)] = EvaluationDetailModel.Empty });
    }

    [RelayCommand]
    private void SortByName()
    {
        if (!_isSortedDescending)
        {
            Evaluations = Evaluations.OrderBy(e => e.StudentName);
            _isSortedDescending = true;
        }
        else
        {
            Evaluations = Evaluations.OrderByDescending(e => e.StudentName);
            _isSortedDescending = false;
        }
    }

    [RelayCommand]

    private void SortByAbbr()
    {
        if (!_isSortedDescending)
        {
            Evaluations = Evaluations.OrderBy(e => e.SubjectAbbr);
            _isSortedDescending= true;
        }
        else
        {
            Evaluations = Evaluations.OrderByDescending(e => e.SubjectAbbr);
            _isSortedDescending = false;
        }
    }

    [RelayCommand]
    private void SortByActivity()
    {
        if (!_isSortedDescending)
        {
            Evaluations = Evaluations.OrderBy(e => e.Activity);
            _isSortedDescending = true;
        }
        else
        {
            Evaluations = Evaluations.OrderByDescending(e => e.Activity);
            _isSortedDescending = false;
        }
    }

    [RelayCommand]
    private void SortByPoints()
    {
        if (!_isSortedDescending)
        {
            Evaluations = Evaluations.OrderBy(e => e.Points);
            _isSortedDescending= true;
        }
        else
        {
            Evaluations = Evaluations.OrderByDescending(e => e.Points);
            _isSortedDescending = false;
        }
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        await navigationService.GoToAsync<EvaluationDetailViewModel>(
            new Dictionary<string, object?> { [nameof(EvaluationDetailViewModel.Id)] = id });
    }
    public async void Receive(EvaluationEditMessage message)
    {
            await LoadDataAsync();
    }

    public async void Receive(EvaluationDeleteMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(SubjectDeleteMessage message)
    {
        await LoadDataAsync();
    }
    public async void Receive(ActivityDeleteMessage message)
    {
        await LoadDataAsync();
    }

    [RelayCommand]
    public async Task Refresh()
    {
        await LoadDataAsync();
    }
}
