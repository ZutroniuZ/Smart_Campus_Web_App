using System.ComponentModel.DataAnnotations;
namespace Smart_Campus_Web_App.Models
{
    public class Authentication
    {
        [Required]
        public required string? Email { get; set; }

        [Required]
        public required string? PasswordHash { get; set; }
    }
}
