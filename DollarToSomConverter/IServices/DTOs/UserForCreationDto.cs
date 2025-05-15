using System.ComponentModel.DataAnnotations;

namespace DollarToSomConverter.IServices.DTOs;

public class UserForCreationDto
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    public required string PasswordHash { get; set; }
}
