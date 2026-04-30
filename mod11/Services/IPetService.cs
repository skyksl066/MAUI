using mod11.Models;

namespace mod11.Services;

public interface IPetService
{
    Task<List<PetModel>> GetPetsAsync();
    Task<PetModel> GetPetByIdAsync(int id);
    Task<int> AddPetAsync(PetModel petModel);
    Task<int> DeletePetAsync(PetModel petModel);
    Task<int> UpdatePetAsync(PetModel petModel);

}
