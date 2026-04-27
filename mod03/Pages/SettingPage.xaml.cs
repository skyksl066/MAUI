namespace mod03.Pages;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
		Lable1.Text = Shell.Current.CurrentState.Location.OriginalString;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}