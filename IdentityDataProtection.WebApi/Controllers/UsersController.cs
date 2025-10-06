using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdentityDataProtection.Data.Context;
using IdentityDataProtection.Data.Entities;
using IdentityDataProtection.WebApi.Models.Auth;
using IdentityDataProtection.Business.Auth;

namespace IdentityDataProtection.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IPasswordService _pw;

        public UsersController(AppDbContext db, IPasswordService pw)
        { _db = db; _pw = pw; }

        // POST /api/users  -> kayıt
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return Conflict(new { message = "Bu e-posta zaten kayıtlı." });

            var user = new UserEntity
            {
                Email = dto.Email.Trim().ToLowerInvariant(),
                PasswordHash = _pw.Hash(dto.Password)
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, new { user.Id, user.Email });
        }

        // GET /api/users/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _db.Users.AsNoTracking()
                .Select(u => new { u.Id, u.Email })
                .FirstOrDefaultAsync(u => u.Id == id);

            return data is null ? NotFound() : Ok(data);
        }

        // GET /api/users -> liste
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _db.Users.AsNoTracking()
               .Select(u => new { u.Id, u.Email }).ToListAsync());
    }
}
