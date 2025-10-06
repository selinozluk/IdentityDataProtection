using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityDataProtection.Business.Auth
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool Verify(string hash, string password);
    }

    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string Hash(string password)
            => _hasher.HashPassword(new object(), password);

        public bool Verify(string hash, string password)
        {
            var r = _hasher.VerifyHashedPassword(new object(), hash, password);
            return r == PasswordVerificationResult.Success
                || r == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}

