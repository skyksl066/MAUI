using mod09.Models;

namespace mod09.Services;

public interface IPetService
{
    Task<List<PetModel>> GetPetsAsync();
    Task<PetModel> GetPetByIdAsync(int id);
    Task<int> AddPetAsync(PetModel petModel);
    Task<int> DeletePetAsync(PetModel petModel);
    Task<int> UpdatePetAsync(PetModel petModel);
}
