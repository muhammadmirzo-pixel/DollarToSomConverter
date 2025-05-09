using DollarToSomConverter.Domain.Commons;

namespace DollarToSomConverter.Domain.Entities;

public class User : Auditable
{
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}
