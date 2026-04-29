using mod09.ViewModels;

namespace mod09.Views;

public partial class TimeView : ContentPage
{
    private readonly TimeViewModel _viewModel;
    public TimeView(TimeViewModel timeViewModel)
	{
		InitializeComponent();
        _viewModel = timeViewModel;
        this.BindingContext = _viewModel;

    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        img.Source = "dog1.jpg";
    }
}