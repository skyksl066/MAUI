using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mod11.Models;
using mod11.Services;

namespace mod11.ViewModels;

[QueryProperty(nameof(Pet), "edit")]
public partial class PetViewModel : ViewModelBase
{
    [ObservableProperty]
    private PetModel pet = new PetModel();
   
    private readonly IPetService _petService;
    public PetViewModel(IPetService petService)
    {
        _petService = petService;
        Title = "寵物";
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    public async void Save(string owner)
    {
        if (Pet.PetId == 0)
        {
            await _petService.AddPetAsync((Pet));
            await Shell.Current.DisplayAlert($"新增{owner}的寵物存檔", Pet.ToString(), "OK");
        }
        else
        {
            await _petService.UpdatePetAsync(Pet);
            await Shell.Current.DisplayAlert($"修改{owner}的寵物存檔", Pet.ToString(), "OK");
        }
        await Shell.Current.GoToAsync("..");
    }

    private bool CanSave(string owner)
    {
        return !string.IsNullOrEmpty(owner);
    }
}
