using System.ComponentModel.DataAnnotations;
namespace Smart_Campus_Web_App.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        public Boolean? UserType { get; set; }

        public Boolean IsOnline { get; set; }
    }
}
