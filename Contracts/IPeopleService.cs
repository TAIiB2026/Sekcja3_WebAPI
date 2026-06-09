using Contracts.DTO;

namespace Contracts
{
    public interface IPeopleService
    {
        Task<IEnumerable<PersonDTO>> GetAsync();
        Task<PersonDTO?> GetByIDAsync(int id);
        Task PostAddress(int personID, string city, string postalCode, string street);
        Task<bool> PostAsync(NewPersonDTO newPersonDTO);
        Task<IEnumerable<AddressDTO>> GetAddresses(int personID);
    }
}
