using mod08.ViewModels;

namespace mod08.Views;

public partial class PetView : ContentPage
{
	private readonly PetViewModel _viewModel = new();
    public PetView()
	{
		InitializeComponent();
		BindingContext = _viewModel;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.DisplayAlert("Àx¦s¦¨¥\", _viewModel.Pet.ToString(), "OK");
    }
}