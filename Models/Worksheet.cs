using System.ComponentModel.DataAnnotations;

namespace EducationConnect.Models;

public class Worksheet
{
    public int Id { get; set; }
    [Required]
    [Url]
    public string Url { get; set; } = "";
    public int UserProfileId { get; set; }
}