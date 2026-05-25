namespace Contracts.DTO
{
    public record NewPersonDTO(string Name, string Surname, 
        DateOnly DateOfBirth);
}
