using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Services;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.ModelViews;
using MinimalApi.Domain.DTOs;
using MinimalApi.Infrastructure.Db;
using MinimalApi.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;

#region Builder
var builder = WebApplication.CreateBuilder(args);

var key = builder.Configuration.GetSection("Jwt").ToString() ?? "123456";

builder.Services.AddAuthentication(option =>
{
   option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
   option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime= true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter only the JWT Token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference 
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    
});

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql"))
    );
});

var app = builder.Build();
#endregion

#region Home 
app.MapGet("/", () => Results.Json(new Home())).AllowAnonymous().WithTags("Home");

#endregion

#region Administrator
string GenerateJwtToken(Administrator administrator)
{
    if (string.IsNullOrEmpty(key))
    {
        return string.Empty;
    }

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim>
    {
      new Claim("Email", administrator.Email),  
      new Claim("accountType", administrator.AccountType),  
      new Claim(ClaimTypes.Role, administrator.AccountType)  
    };

    var token = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}

app.MapPost("/administrator/login", ([FromBody] LoginDTO loginDTO, IAdministratorService administratorService) =>
{
    var adm = administratorService.Login(loginDTO);

    if (adm == null)
    {
        return Results.Unauthorized();
    } 

    string token = GenerateJwtToken(adm);

    return Results.Ok(new AdmLogged
    {
        Email= adm.Email,
        AccountType= (AccountType) Enum.Parse(typeof(AccountType), adm.AccountType),
        Token= token
    });
})
.AllowAnonymous().WithTags("Administrator", "Users");

app.MapPost("/administrator", ([FromBody] AdministratorDTO administratorDTO, IAdministratorService administratorService) =>
{
    var validation = new ValidationErrors { Messages= new List<string>() };

    if (string.IsNullOrEmpty(administratorDTO.Email))
    {
        validation.Messages.Add("Administrator's e-mail cannot be null");
    }
    if (string.IsNullOrEmpty(administratorDTO.Password))
    {
        validation.Messages.Add("Administrator's password cannot be null");
    }
    if (string.IsNullOrEmpty(administratorDTO.AccountType.ToString()))
    {
        validation.Messages.Add("Invalid administrator's account type");
    }

    if (validation.Messages.Count > 0)
    {
        return Results.BadRequest(validation.Messages);
    }

    var administrator = new Administrator
    {
        Email= administratorDTO.Email,
        Password= administratorDTO.Password,
        AccountType= administratorDTO.AccountType.ToString() ?? AccountType.Editor.ToString()
    };

    administratorService.Register(administrator);

    return Results.Created($"/administrator/{administrator}", administrator);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles= "Adm" })
.WithTags("Administrator", "Users");

app.MapGet("/administrator", ([FromQuery] int page, IAdministratorService administratorService) =>
{
    var result = new List<AdministratorModelView>();
    var administrators = administratorService.All(page);

    foreach (var adm in administrators)
    {
        result.Add(new AdministratorModelView
        {
            Id= adm.Id,
            Email= adm.Email,
            AccountType= (AccountType) Enum.Parse(typeof(AccountType), adm.AccountType)
        });
    }

    return Results.Ok(result);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles= "Adm" })
.WithTags("Administrator", "Users");

app.MapGet("/administrator/{id}", ([FromRoute] int id, IAdministratorService administratorService) =>
{
    var administrator = administratorService.FindById(id);

    if (administrator == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new AdministratorModelView
    {
        Id= administrator.Id,
        Email= administrator.Email,
        AccountType= (AccountType) Enum.Parse(typeof(AccountType), administrator.AccountType)
    });
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles= "Adm" })
.WithTags("Administrator", "Users");
#endregion

#region Vehicles
ValidationErrors verifyDTO(VehicleDTO vehicleDTO)
{
    var validation = new ValidationErrors { Messages= new List<string>() };
    
    if (string.IsNullOrEmpty(vehicleDTO.Name))
    {
        validation.Messages.Add("Vehicle's name cannot be null");
    }
    if (string.IsNullOrEmpty(vehicleDTO.Brand))
    {
        validation.Messages.Add("Vehicle's brand must be fill in");
    }
    if (vehicleDTO.Year <= 1950)
    {
        validation.Messages.Add("Vehicle's year is invalid");
    }

    return validation;
}

app.MapPost("/vehicle/add", ([FromBody] VehicleDTO vehicleDTO, IVehicleService vehicleService) =>
{
    var validation = verifyDTO(vehicleDTO);

    if (validation.Messages.Count > 0)
    {
        return Results.BadRequest(validation.Messages);
    }

    var vehicle = new Vehicle
    {
        Name = vehicleDTO.Name,
        Brand = vehicleDTO.Brand,
        Year = vehicleDTO.Year
    };

    vehicleService.Insert(vehicle);

    return Results.Created($"/vehicle/{vehicle}", vehicle);
}).RequireAuthorization().WithTags("Vehicle");

app.MapGet("/vehicle", ([FromQuery] int? page, IVehicleService vehicleService) =>
{
    var vehicles = vehicleService.All(page);

    return Results.Ok(vehicles);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles= "Adm,Editor" })
.WithTags("Vehicle");

app.MapGet("/vehicle/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.FindById(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(vehicle);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles= "Adm,Editor" })
.WithTags("Vehicle");

app.MapPut("/vehicle/{id}", ([FromRoute] int id, [FromBody] VehicleDTO vehicleDTO, IVehicleService vehicleService) =>
{
    var validation = verifyDTO(vehicleDTO);

    if (validation.Messages.Count > 0)
    {
        return Results.BadRequest(validation.Messages);
    }

    var vehicle = vehicleService.FindById(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    vehicle.Name = vehicleDTO.Name;
    vehicle.Brand = vehicleDTO.Brand;
    vehicle.Year = vehicleDTO.Year;

    vehicleService.Update(vehicle);

    return Results.Ok(vehicle);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles= "Adm" })
.WithTags("Vehicle");

app.MapDelete("/vehicle/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.FindById(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    vehicleService.Delete(vehicle);

    return Results.NoContent();
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles= "Adm" })
.WithTags("Vehicle");
#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
#endregion