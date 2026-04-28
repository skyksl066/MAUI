namespace mod06.Views;

public partial class UseEditor : ContentPage
{
	public UseEditor()
	{
		InitializeComponent();
	}

    private void userName_TextChanged(object sender, TextChangedEventArgs e)
    {
        lblOld.Text = e.OldTextValue;
        lblNew.Text = e.NewTextValue;
    }

    private void userName_Completed(object sender, EventArgs e)
    {
        lblCompleted.Text = $"Completed: {DateTime.Now}";
    }

    private async void btnSend_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Submitted", $"UserName: {userName.Text} \nPassword: {password.Text} \nPhone:{telephone.Text}\nNote:{note.Text}", "OK");
    }

}