using mod11.Models;
using System.Net.Http.Json;

namespace mod11.Services;

public class PetServiceFormWeb : IPetService
{
    static readonly string baseURL =
        DeviceInfo.Platform == DevicePlatform.Android ?
        "https://10.0.2.2:7046/api/pets/" : "https://localhost:7046/api/pets/";

    //static readonly string baseURL =
    //    DeviceInfo.Platform == DevicePlatform.Android ?
    //    "http://10.0.2.2/UN498/api/pets/" : "http://localhost/UN498/api/pets/";
    static readonly HttpClient _httpClient;

    static PetServiceFormWeb()
    {
        var handler = new HttpsClientHandlerService();
        _httpClient = new HttpClient(handler.GetPlatformMessageHandler())
        {
            BaseAddress = new Uri(baseURL)
        };
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        Connectivity.ConnectivityChanged += (s, e) => IsInternet();
    }

    private static bool IsInternet()
    {
        var isInternet = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        if (!isInternet)
        {
            AppShell.Current.DisplayAlert("Error", "目前網路無法連上 Internet ", "OK");
        }
        return isInternet;
    }

    public async Task<int> AddPetAsync(PetModel petModel)
    {
        var result = 0;
        if (!IsInternet()) return result;
        try
        {
            var response = await _httpClient.PostAsJsonAsync<PetModel>("", petModel);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            await AppShell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
        }
        return result;

    }

    public async Task<int> DeletePetAsync(PetModel petModel)
    {
        var result = 0;
        if (!IsInternet()) return result;
        try
        {
            var response = await _httpClient.DeleteAsync($"{petModel.PetId}");
            response.EnsureSuccessStatusCode();
            result = 1;
        }
        catch (Exception ex)
        {
            await AppShell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
        }

        return result;
    }

    public async Task<PetModel> GetPetByIdAsync(int id)
    {
        PetModel result = new();
        if (!IsInternet()) return result;

        var response = await _httpClient.GetAsync(id.ToString());

        if (response.IsSuccessStatusCode)
            result = await response.Content.ReadFromJsonAsync<PetModel>();
        else
            await AppShell.Current.DisplayAlert("Error:", $"{response.StatusCode}", "OK");
        return result;

    }

    public async Task<List<PetModel>> GetPetsAsync()
    {
        List<PetModel> result = [];
        if (!IsInternet()) return result;

        try
        {
            result = await _httpClient.GetFromJsonAsync<List<PetModel>>("");
        }
        catch (Exception ex)
        {
            await AppShell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
        }
        return result;

    }

    public async Task<int> UpdatePetAsync(PetModel petModel)
    {
        var result = 0;
        if (!IsInternet()) return result;
        try
        {
            var response = await _httpClient.PutAsJsonAsync<PetModel>(petModel.PetId.ToString(), petModel);
            response.EnsureSuccessStatusCode();
            result = 1;
        }
        catch (Exception ex)
        {
            await AppShell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
        }
        return result;

    }
}
