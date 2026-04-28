namespace mod04.Views;

public partial class VStackLayoutPage : ContentPage
{
	public VStackLayoutPage()
	{
		InitializeComponent();
	}

    private void btnChangeMargin_Click(object sender, EventArgs e)
    {
        btnChangeMargin.TextColor = Colors.Black;
        btnChangeMargin.Margin = new Thickness(10, 20, 30, 40);

    }

    private void btnChangePadding_Clicked(object sender, EventArgs e)
    {
        btnChangePadding.TextColor = Colors.Black;
        btnChangePadding.Padding = new Thickness(20);

    }
}