using ICS.App.ViewModels;

namespace ICS.App.Views.Student;

public partial class StudentListView
{
    public StudentListView(StudentListViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
    /*public StudentListView()
    {
        InitializeComponent();
    }*/
}
