using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;

namespace ICS.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]

public partial class SubjectDetailViewModel(
    ISubjectFacade subjectFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<SubjectEditMessage>
{

    public Guid Id { get; set; }
    public SubjectDetailModel? Subject { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subject = await subjectFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Subject is not null)
        {
            await subjectFacade.DeleteAsync(Subject.Id);
            MessengerService.Send(new SubjectDeleteMessage());

            navigationService.SendBackButtonPressed();
        }
    }


    [RelayCommand]
    private async Task GoToEditAsync()
    {
        if (Subject is not null)
        {
            await navigationService.GoToAsync("/edit",
                new Dictionary<string, object?> { [nameof(SubjectEditViewModel.Subject)] = Subject});
        }
    }

    public async void Receive(SubjectEditMessage message)
    {
        if (message.SubjectId == Subject?.Id)
        {
            await LoadDataAsync();
        }
    }

    public async void Receive(SubjectDeleteMessage message)
    {
        await LoadDataAsync();
    }


}
