using DollarToSomConverter.Domain_folder;

namespace DollarToSomConverter.Entities;

public class User : Auditable
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsVerified { get; set; } = false;
}