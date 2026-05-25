using Contracts.DTO;

namespace Contracts
{
    public interface IPeopleService
    {
        Task<IEnumerable<PersonDTO>> GetAsync();
        Task<PersonDTO?> GetByIDAsync(int id);
        Task<bool> PostAsync(NewPersonDTO newPersonDTO);
    }
}
