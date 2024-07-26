using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EducationConnect.Models.DTOs;

public class UserProfileDTO
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
    [Required]
    [MaxLength(100)]
    [MinLength(1)]
    [EmailAddress]
    public string Email { get; set; } = "";
    public List<string> Roles { get; set; } = [];
    public string IdentityUserId { get; set; } = "";
    public IdentityUser? IdentityUser { get; set; }
}