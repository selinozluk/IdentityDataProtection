# Identity & Data Protection – Practice

Bu repo, **Identity & Data Protection** ödevi için hazırlanmış .NET 8 çok katmanlı Web API örneğidir.  
Amaç: `User` tablosu (**Id, Email, PasswordHash**), **Model Validation** ve **kayıtta parolanın hash’lenmesi**.

---

## 🎯 Özellikler
- EF Core **Code-First** ile `Users` tablosu
- `[Required]`, `EmailAddress`, `MaxLength` doğrulamaları
- **ASP.NET Core Identity PasswordHasher** ile **hash’li parola**
- Minimal **Users API**: Register, GetById, GetAll
- Swagger / OpenAPI

---

## 🧱 Proje Yapısı
IdentityDataProtection/
├─ IdentityDataProtection.sln
├─ IdentityDataProtection.Data
│ ├─ Entities/
│ │ └─ UserEntity.cs
│ └─ Context/
│ └─ AppDbContext.cs
├─ IdentityDataProtection.Business
│ └─ Auth/
│ └─ PasswordService.cs
└─ IdentityDataProtection.WebApi
├─ Controllers/
│ └─ UsersController.cs
├─ Models/
│ └─ Auth/
│ └─ RegisterUserDto.cs
├─ appsettings.json
└─ Program.cs

---

## 🛠️ Gereksinimler
- .NET SDK **8.0+**
- SQL Server / LocalDB
- Visual Studio 2022 veya VS Code

---

## 📦 NuGet Paketleri

**WebApi**
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.EntityFrameworkCore.Tools`

**Data**
- `Microsoft.EntityFrameworkCore`
- (opsiyonel) `Microsoft.EntityFrameworkCore.Relational`

**Business**
- `Microsoft.AspNetCore.Identity`

> PMC ile kurulum örneği:
> ```powershell
> Install-Package Microsoft.EntityFrameworkCore.SqlServer -ProjectName IdentityDataProtection.WebApi
> Install-Package Microsoft.EntityFrameworkCore.Design    -ProjectName IdentityDataProtection.WebApi
> Install-Package Microsoft.EntityFrameworkCore.Tools     -ProjectName IdentityDataProtection.WebApi
> Install-Package Microsoft.EntityFrameworkCore           -ProjectName IdentityDataProtection.Data
> Install-Package Microsoft.AspNetCore.Identity           -ProjectName IdentityDataProtection.Business
> ```

---

## ⚙️ Konfigürasyon

**IdentityDataProtection.WebApi/appsettings.json**
```json
{
  "ConnectionStrings": {
    "Default": "Server=SELIN;Database=IdentityDPDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning" } },
  "AllowedHosts": "*"
}
