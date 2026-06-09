using System.Collections.ObjectModel;

namespace Models
{
    public class PersonEntity
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Collection<AddressEntity> Addresses { get; set; }
    }
}
