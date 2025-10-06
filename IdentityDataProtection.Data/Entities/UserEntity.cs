using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdentityDataProtection.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = null!;

        [Required] // düz şifre değil, HASH saklanır
        public string PasswordHash { get; set; } = null!;
    }
}

