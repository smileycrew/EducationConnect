using System.ComponentModel.DataAnnotations;

namespace EducationConnect.Models;

public class UserProfile
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [MinLength(1)]
    public string FirstName { get; set; } = "";
    [Required]
    [MaxLength(50)]
    [MinLength(1)]
    public string LastName { get; set; } = "";
    public string? IdentityUserId { get; set; }
}