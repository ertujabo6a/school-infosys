using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Services;
using ICS.BL.Models;
using ICS.BL.Facades.Interfaces;
using ICS.App.Messages;
using System.Windows.Input;

namespace ICS.App.ViewModels;

public partial class StudentListViewModel(
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<StudentEditMessage>, IRecipient<StudentDeleteMessage>
{
    public IEnumerable<StudentListModel> Students { get; private set; } = null!;

    public StudentListModel StudentToSearch { get; init; } = StudentListModel.Empty;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Students = await studentFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/edit");
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        await navigationService.GoToAsync<StudentDetailViewModel>(
            new Dictionary<string, object?> { [nameof(StudentDetailViewModel.Id)] = id });
    }

    [RelayCommand]
    private void SortByName()
    {
        Students = Students.OrderBy(e => e.Name);
    }

    [RelayCommand]
    private void SortBySurname()
    {
        Students = Students.OrderBy(e => e.Surname);
    }

    [RelayCommand]
    private async Task SearchStudent()
    {
        string[] parts = StudentToSearch.Name.Split(' ');
        if (string.IsNullOrEmpty(StudentToSearch.Name))
        {
            Students = await studentFacade.GetAsync();
        }
        else
        {
            if(parts.Length == 1)
            {
                Students = Students.Where(s => s.Name.Contains(parts[0]) || s.Surname.Contains(parts[0]));
            }
            else if (parts.Length == 2)
            {
                Students = Students.Where(s => s.Name.Contains(parts[0]) || s.Surname.Contains(parts[1]));
            }
            else
            {
                Students = null!;
            }
        }
    }

    public async void Receive(StudentEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(StudentDeleteMessage message)
    {
        await LoadDataAsync();
    }
}
