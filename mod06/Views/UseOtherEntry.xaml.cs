namespace mod06.Views;

public partial class UseOtherEntry : ContentPage
{
	public UseOtherEntry()
	{
		InitializeComponent();
	}

    private void chk1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        chkResult.Text = e.Value.ToString();
    }

    private void switch1_Toggled(object sender, ToggledEventArgs e)
    {
        switchResult.Text = e.Value.ToString();
    }

    private void slider1_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        sliderResult.Text = $"{e.OldValue:00.000} => {e.NewValue:00.000}";
    }

    private void slider1_DragStarted(object sender, EventArgs e)
    {
        sliderAction.Text = "DragStarted";
    }

    private void slider1_DragCompleted(object sender, EventArgs e)
    {
        sliderAction.Text = "DragCompleted";
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        stepperResult.Text = $"{e.OldValue:00.000} => {e.NewValue:00.000}";
    }
}