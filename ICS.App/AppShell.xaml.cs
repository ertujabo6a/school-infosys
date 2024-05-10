using ICS.App.Services;

namespace ICS.App;

public partial class AppShell
{
    private readonly INavigationService _navigationService;

    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;

        InitializeComponent();
    }
}
