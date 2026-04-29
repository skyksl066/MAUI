using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mod08.Models;

namespace mod08.ViewModels
{
    public partial class Lab03PetViewModel : Lab03ViewModelBase
    {
        [ObservableProperty]
        private Lab03PetModel _pet = new();

        public Lab03PetViewModel()
        {
            Title = "寵物";
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        public async void Save(string owner)
        {
            await Shell.Current.DisplayAlert($"{owner}的寵物存檔", Pet.ToString(), "OK");
            await Shell.Current.GoToAsync("//MainPage");
        }

        private bool CanSave(string owner)
        {
            return !string.IsNullOrEmpty(owner);
        }
    }
}
