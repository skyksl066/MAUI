using System.Collections.ObjectModel;

namespace mod07.Views;

public partial class UsePicker : ContentPage
{
	//List<string> PetType = [];
    ObservableCollection<string> PetType;

    public UsePicker()
	{
		InitializeComponent();
        //PetType.AddRange(["Dog", "Cat", "Mouse", "Bird"]);
        PetType = ["Dog", "Cat", "Mouse", "Bird"];
        picker.ItemsSource = PetType;

    }

    private void addButton_Clicked(object sender, EventArgs e)
    {
        PetType.Add("pig");
    }

    private void removeButton_Clicked(object sender, EventArgs e)
    {
        PetType.Remove(picker.SelectedItem?.ToString() ?? "");
    }
}