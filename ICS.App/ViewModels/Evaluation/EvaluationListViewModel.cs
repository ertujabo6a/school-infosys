using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;


namespace ICS.App.ViewModels;

public partial class EvaluationListViewModel(
    IEvaluationFacade evaluationFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<EvaluationEditMessage>, IRecipient<EvaluationDeleteMessage>
{
    public IEnumerable<EvaluationListModel> Evaluations { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Evaluations = await evaluationFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/edit");
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
}
