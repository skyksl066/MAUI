using mod07.Models;
using System.Collections.ObjectModel;

namespace mod07.Views;

public partial class UseCollectionView : ContentPage
{
    public ObservableCollection<PetModel> Pets { get; set; } = [];

    public UseCollectionView()
	{
		InitializeComponent();
		this.BindingContext = this;
	}

    private void addButton_Clicked(object sender, EventArgs e)
    {
        Pets.Add(new PetModel()
        {
            PetId = 101,
            PetName = "Dog1",
            PictureUrl = "dotnet_bot.png",
            Type = "Dog",
            Owner = "You",
            AdopDate = new DateTime(2020, 1, 1)
        });

    }

    private void clearButton_Clicked(object sender, EventArgs e)
    {
        Pets.Clear();
    }
}