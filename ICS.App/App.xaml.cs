using ICS.App.ViewModels;
using ICS.App.ViewModels.Subject;
using ICS.App.Views;
using ICS.App.Views.Student;

namespace ICS.App;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        var aaa = serviceProvider.GetRequiredService<StudentListView>();
        MainPage = serviceProvider.GetRequiredService<AppShell>();
    }
}
