namespace mod04.Views;

public partial class StackLayoutPage : ContentPage
{
	public StackLayoutPage()
	{
		InitializeComponent();
	}

    private void btnChangeLayout_Clicked(object sender, EventArgs e)
    {
        stack1.Orientation = StackOrientation.Vertical;
        lblOrange.HorizontalOptions = LayoutOptions.Start;
        lblYellow.HorizontalOptions = LayoutOptions.End;
        lblGreen.HorizontalOptions = LayoutOptions.Center;
        lblBlue.HorizontalOptions = LayoutOptions.Fill;
        lblBlue.Text = "Fill";

    }
}