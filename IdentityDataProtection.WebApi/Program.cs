using IdentityDataProtection.Business.Auth;
using IdentityDataProtection.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* ---------- Services ---------- */

// EF Core (appsettings.json -> ConnectionStrings:Default)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        b => b.MigrationsAssembly("IdentityDataProtection.WebApi") // <- eklendi
    )
);

// Parola hash servisi (Identity PasswordHasher sarmalayýcýsý)
builder.Services.AddScoped<IPasswordService, PasswordService>();

// Data Protection (ödev kapsamýnda)
builder.Services.AddDataProtection();

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/* ---------- Middleware pipeline ---------- */

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
