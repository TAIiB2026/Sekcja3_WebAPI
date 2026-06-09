using Contracts;
using Contracts.DTO;
using Models;

namespace Services.Memory
{
    public class PeopleService : IPeopleService
    {
        private static int ID_GENERATOR = 1;

        private static readonly List<PersonEntity> repository = [
            new PersonEntity {
                ID = ID_GENERATOR++,
                Name = "Jan",
                Surname = "Kowalski",
                DateOfBirth = new DateOnly(1990, 2, 25),
                Email = "jan.kowalski@wp.pl",
                PhoneNumber = "999000888"
            },
            new PersonEntity {
                ID = ID_GENERATOR++,
                Name = "Adam",
                Surname = "Nowak",
                DateOfBirth = new DateOnly(1986, 3, 10),
                Email = "adam.nowak@onet.pl",
                PhoneNumber = "112233344"
            },
            new PersonEntity {
                ID = ID_GENERATOR++,
                Name = "Anna",
                Surname = "Iksińska",
                DateOfBirth = new DateOnly(1995, 10, 2),
                Email = "anna.iksinska@iks.pl",
                PhoneNumber = "999888765"
            },
            new PersonEntity {
                ID = ID_GENERATOR++,
                Name = "Natalia",
                Surname = "Kowalska",
                DateOfBirth = new DateOnly(1966, 4, 14),
                Email = "natalia.kowalska@iks.pl",
                PhoneNumber = "112309876"
            },
            new PersonEntity {
                ID = ID_GENERATOR++,
                Name = "Jan",
                Surname = "Igrekowy",
                DateOfBirth = new DateOnly(2005, 1, 11),
                Email = "jan.igrekowy@iks.pl",
                PhoneNumber = "988777653"
            },
        ];

        public Task<IEnumerable<PersonDTO>> GetAsync()
        {
            var response = repository.Select(x => 
                new PersonDTO(x.ID, x.Name, x.Surname, x.DateOfBirth));
            return Task.FromResult(response);
        }

        public Task<PersonDTO?> GetByIDAsync(int id)
        {
            PersonDTO? response;
            PersonEntity? personEntity = repository.Find(x => x.ID == id);
            if(personEntity is null)
            {
                response = null;
            } else
            {
                response = new PersonDTO(personEntity.ID, personEntity.Name, 
                    personEntity.Surname, personEntity.DateOfBirth);
            }

            return Task.FromResult(response);
        }

        public Task<bool> PostAsync(NewPersonDTO newPersonDTO)
        {
            bool response;

            if (repository.Count >= 10)
            {
                response = false;
            }
            else
            {
                var newPerson = new PersonEntity
                {
                    Name = newPersonDTO.Name,
                    Surname = newPersonDTO.Surname,
                    DateOfBirth = newPersonDTO.DateOfBirth,
                    ID = ID_GENERATOR++,
                    Email = null,
                    PhoneNumber = null
                };

                repository.Add(newPerson);
                response = true;
            }

            return Task.FromResult(response);
        }

        public Task PostAddress(int personID, string city, string postalCode, string street)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressDTO>> GetAddresses(int personID)
        {
            throw new NotImplementedException();
        }
    }
}