using DAL;
using Models;
using System.Reflection.Emit;

namespace Seed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonEntity> repository = [
            new PersonEntity {
                Name = "Jan",
                Surname = "Kowalski",
                DateOfBirth = new DateOnly(1990, 2, 25),
                Email = "jan.kowalski@wp.pl",
                PhoneNumber = "999000888",
                Addresses = [
                        new AddressEntity
                        {
                            City = "Katowice",
                            Street = "Dworcowa",
                            PostCode = "41-003",
                        },
                        new AddressEntity
                        {
                            City = "Gliwce",
                            Street = "Akademicka",
                            PostCode = "43-003"
                        },
                        new AddressEntity
                        {
                            City = "Gdańsk",
                            Street = "Złota",
                            PostCode = "21-303"
                        }
                    ]
            },
            new PersonEntity {
                Name = "Adam",
                Surname = "Nowak",
                DateOfBirth = new DateOnly(1986, 3, 10),
                Email = "adam.nowak@onet.pl",
                PhoneNumber = "112233344"
            },
            new PersonEntity {
                Name = "Anna",
                Surname = "Iksińska",
                DateOfBirth = new DateOnly(1995, 10, 2),
                Email = "anna.iksinska@iks.pl",
                PhoneNumber = "999888765"
            },
            new PersonEntity {
                Name = "Natalia",
                Surname = "Kowalska",
                DateOfBirth = new DateOnly(1966, 4, 14),
                Email = "natalia.kowalska@iks.pl",
                PhoneNumber = "112309876"
            },
            new PersonEntity {
                Name = "Jan",
                Surname = "Igrekowy",
                DateOfBirth = new DateOnly(2005, 1, 11),
                Email = "jan.igrekowy@iks.pl",
                PhoneNumber = "988777653"
            },
        ];

            using(PeopleContext peopleContext = new PeopleContext())
            {
                peopleContext.AddRange(repository);
                peopleContext.SaveChanges();
            }
        }
    }
}
