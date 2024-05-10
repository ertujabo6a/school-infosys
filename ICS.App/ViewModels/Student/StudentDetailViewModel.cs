using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ICS.App.Messages;
using ICS.App.Services;
using ICS.BL.Facades.Interfaces;
using ICS.BL.Models;

namespace ICS.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class StudentDetailViewModel(
    IStudentFacade studentFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<StudentEditMessage>
{
    private readonly IMessengerService _messengerService = messengerService;

    public Guid Id { get; set; }
    public StudentDetailModel? Student { get; private set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Student = await studentFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Student is not null)
        {
            await studentFacade.DeleteAsync(Student.Id);
            _messengerService.Send(new StudentDeleteMessage());
            navigationService.SendBackButtonPressed();
        }
    }

    [RelayCommand]
    private async Task GoToEditAsync()
    {
        await navigationService.GoToAsync("/edit",
            new Dictionary<string, object?> { [nameof(Student)] = Student });
    }

    public async void Receive(StudentEditMessage message)
    {
        if (message.StudentId == Student?.Id)
        {
            await LoadDataAsync();
        }
    }
}
