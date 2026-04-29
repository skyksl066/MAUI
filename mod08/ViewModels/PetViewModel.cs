using mod08.Models;
using System.Windows.Input;

namespace mod08.ViewModels
{
    public class PetViewModel : ViewModelBase
    {
        private PetModel _pet = new();
        public ICommand Save { private set; get; }

        public PetModel Pet
        {
            get => _pet;
            set
            {
                if (_pet != value)
                {
                    _pet = value;
                    OnPropertyChanged();
                }
            }
        }

        public PetViewModel()
        {
            Title = "寵物";
            Command<string> saveCommand = new(
               execute: async (owner) =>
               {
                   await Shell.Current.DisplayAlert($"{owner} 的寵物存檔", Pet.ToString(), "OK");
                   await Shell.Current.GoToAsync("..");
               },
               canExecute: (owner) => !string.IsNullOrEmpty(owner)
            );
            Save = saveCommand;
        }

    }
}
