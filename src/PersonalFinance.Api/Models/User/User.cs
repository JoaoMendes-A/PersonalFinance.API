using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Api.Models.User;

public class User()
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(40)]    
    public string UserName { get; set; } = string.Empty;

    [Required]
    [MaxLength(60)]    
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]    
    public string HashPassword { get; set; } = string.Empty;
};