using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;

namespace ICS.App.ViewModels;

public partial class SubjectListViewModel(
    ISubjectFacade subjectFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<SubjectEditMessage>, IRecipient<SubjectDeleteMessage>
{
    public Guid Id { get; set; }


    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;
    public SubjectListModel SubjectToSearch { get; init; } = SubjectListModel.Empty;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subjects = await subjectFacade.GetAsync();
    }

    [RelayCommand]
    private void SortBySubjectAbbr()
    {
        Subjects = Subjects.OrderBy(e => e.SubjectAbbr);
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/edit");
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        await navigationService.GoToAsync<SubjectDetailViewModel>(
            new Dictionary<string, object?> { [nameof(SubjectDetailViewModel.Id)] = id });
    }

    [RelayCommand]
    private async Task SearchSubject()
    {
        string search = SubjectToSearch.SubjectAbbr;
        if (string.IsNullOrEmpty(SubjectToSearch.SubjectAbbr))
        {
            Subjects = await subjectFacade.GetAsync();
        }
        else
        {
            Subjects = Subjects.Where(s => s.SubjectAbbr.Contains(search));

        }
    }

    public async void Receive(SubjectEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(SubjectDeleteMessage message)
    {
        await LoadDataAsync();
    }
}
