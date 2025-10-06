using System.ComponentModel.DataAnnotations;

namespace IdentityDataProtection.WebApi.Models.Auth
{
    public class RegisterUserDto
    {
        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = null!;

        [Required, MinLength(6), MaxLength(100)]
        public string Password { get; set; } = null!;
    }
}
