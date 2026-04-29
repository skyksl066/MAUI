using mod08.ViewModels;

namespace mod08.Views;

public partial class Lab03PetView : ContentPage
{
    private readonly Lab03PetViewModel _viewModel = new();
    public Lab03PetView()
	{
		InitializeComponent();
        BindingContext = _viewModel;
	}
}