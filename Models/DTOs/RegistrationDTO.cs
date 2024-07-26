using System.ComponentModel.DataAnnotations;

namespace EducationConnect.Models.DTOs;

public class RegistrationDTO
{
    [Required]
    [MaxLength(100)]
    [MinLength(1)]
    [EmailAddress]
    public string Email { get; set; } = "";
    [Required]
    [MaxLength(50)]
    [MinLength(1)]
    public string FirstName { get; set; } = "";
    [Required]
    [MaxLength(50)]
    [MinLength(1)]
    public string LastName { get; set; } = "";
    [Required]
    [MaxLength(50)]
    [MinLength(12)]
    public string Password { get; set; } = "";
}