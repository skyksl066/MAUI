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

        [RelayCommand]
        public async void Edit(PetModel pet)
        {
            var param = new Dictionary<string, object>();
            param.Add("edit", pet);
            await AppShell.Current.GoToAsync(nameof(PetView), param);
        }

        [RelayCommand]
        public async void Delete(PetModel pet)
        {
            IsRefreshing = true;
            var alert = await AppShell.Current.DisplayAlert("刪除: ", $"是否刪除 {pet}", "確定", "取消");
            if (alert)
            {
                var result = await _petService.DeletePetAsync(pet);
                if (result > 0)
                    await this.GetPetsAsync();
            }
            IsRefreshing = false;
        }
    }
}
