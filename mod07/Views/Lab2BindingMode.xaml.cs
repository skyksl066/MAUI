namespace mod07.Views;

public partial class Lab2BindingMode : ContentPage
{
	public Lab2BindingMode()
	{
		InitializeComponent();

		
        srcEntry.Text = "First Time";
        tgEntry.SetBinding(Entry.TextProperty, static (Entry e) => e.Text, source: srcEntry);

        tgOneTime.SetBinding(Entry.TextProperty, static (Entry e) => e.Text, mode: BindingMode.OneTime, source: srcEntry);
    }
}