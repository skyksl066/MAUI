using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mod09.Models;
using mod09.Services;
using mod09.Views;
using System.Collections.ObjectModel;

namespace mod09.ViewModels
{
    public partial class PetListViewModel : ViewModelBase
    {
        public ObservableCollection<PetModel> PetList { get; } = new();
        [ObservableProperty]
        private bool isRefreshing;

        private readonly IPetService _petService;

        public PetListViewModel(IPetService petService)
        {
            Title = "寵物清單";
            _petService = petService;
            isRefreshing = true;
        }

        [RelayCommand]
        public async Task Add()
        {
            await AppShell.Current.GoToAsync(nameof(PetView));
        }

        [RelayCommand]
        public async Task GetPetsAsync()
        {
            var list = await _petService.GetPetsAsync();
            PetList.Clear();
            foreach (var item in list)
            {
                PetList.Add(item);
            }
            IsRefreshing = false;
        }
    }
}
