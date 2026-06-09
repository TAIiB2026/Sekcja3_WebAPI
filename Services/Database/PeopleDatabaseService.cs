using Contracts;
using Contracts.DTO;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.Database
{
    public class PeopleDatabaseService : IPeopleService
    {
        private readonly PeopleContext peopleContext;

        public PeopleDatabaseService(PeopleContext peopleContext)
        {
            this.peopleContext = peopleContext;
        }

        public async Task<IEnumerable<PersonDTO>> GetAsync()
        {
            //var data2 = await this.peopleContext.peopleDbSet.Select(x => new
            //{
            //    x.ID,
            //    x.Name,
            //    x.Surname,
            //    x.DateOfBirth
            //})
            //.ToListAsync();

            var data = await this.peopleContext.peopleDbSet.ToListAsync();

            return data
                .Select(x => new PersonDTO(x.ID, x.Name, x.Surname, x.DateOfBirth));
        }

        public async Task<PersonDTO?> GetByIDAsync(int id)
        {
            var data = await this.peopleContext.peopleDbSet.FirstOrDefaultAsync(x => x.ID == id);
            if(data == null)
            {
                return null;
            }

            return new PersonDTO(data.ID, data.Name, data.Surname, data.DateOfBirth);
        }

        public async Task<bool> PostAsync(NewPersonDTO newPersonDTO)
        {
            PersonEntity personEntity = new PersonEntity
            {
                Name = newPersonDTO.Name,
                Surname = newPersonDTO.Surname,
                DateOfBirth = newPersonDTO.DateOfBirth,
                Email = "",
                PhoneNumber = ""
            };

            await this.peopleContext.AddAsync(personEntity);

            try
            {
                await this.peopleContext.SaveChangesAsync();
                return true;
            } catch
            {
                return false;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var data = await peopleContext.peopleDbSet.FindAsync(id);

            if(data is not null)
            {
                peopleContext.Remove(data);
                await peopleContext.SaveChangesAsync();
            }
        }

        public async Task Delete2Async(int id)
        {
            await peopleContext.peopleDbSet
                .Where(x => x.ID == id)
                .ExecuteDeleteAsync();
        }

        public async Task PostAddress(int personID, string city, string postalCode, string street)
        {
            PersonEntity personEntity = await peopleContext.peopleDbSet.FindAsync(personID);

            AddressEntity addressEntity = new AddressEntity
            {
                City = city,
                PostCode = postalCode,
                Street = street,
                Person = personEntity
            };

            await this.peopleContext.AddAsync(addressEntity);
            await this.peopleContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AddressDTO>> GetAddresses(int personID)
        {
            var data = await this.peopleContext.peopleDbSet
                .Include(x => x.Addresses)
                .FirstAsync(x => x.ID == personID);

            return data.Addresses.Select(x => new AddressDTO(x.Person.ID, x.Person.Name, x.PostCode, x.City, x.Street));
        }
    }
}
