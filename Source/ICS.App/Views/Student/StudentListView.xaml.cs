using ICS.App.ViewModels.Student;

namespace ICS.App.Views.Student;

public partial class StudentListView : ContentPageBase
{

    public StudentListView(StudentListViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
