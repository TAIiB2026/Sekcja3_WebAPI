namespace Contracts.DTO
{
    public record PersonDTO(int ID, string Name, 
        string Surname, DateOnly DateOfBirth);
}
