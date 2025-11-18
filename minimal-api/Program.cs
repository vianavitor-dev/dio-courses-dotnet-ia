using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Services;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.ModelViews;
using MinimalApi.Domain.DTOs;
using MinimalApi.Infrastructure.Db;
using MinimalApi.Domain.Enums;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();
#endregion

#region Home 
app.MapGet("/", () => Results.Json(new Home())).WithTags("Home");

#endregion

#region Administrator
app.MapPost("/administrator/login", ([FromBody] LoginDTO loginDTO, IAdministratorService administratorService) =>
{
    if (administratorService.Login(loginDTO) == null)
    {
        return Results.Unauthorized();
    } 

    return Results.Ok("User logged");
}).WithTags("Administrator", "Users");

app.MapPost("/administrator", ([FromBody] Administrator administratorDTO, IAdministratorService administratorService) =>
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
    if (string.IsNullOrEmpty(administratorDTO.AccountType))
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
        Password= administratorDTO.Email,
        AccountType= administratorDTO.AccountType.ToString() ?? AccountType.Editor.ToString()
    };

    administratorService.Register(administrator);

    return Results.Created($"/administrator/{administrator}", administrator);
}).WithTags("Administrator", "Users");

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
}).WithTags("Administrator", "Users");

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
}).WithTags("Administrator", "Users");
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
}).WithTags("Vehicle");

app.MapGet("/vehicle", ([FromQuery] int? page, IVehicleService vehicleService) =>
{
    var vehicles = vehicleService.All(page);

    return Results.Ok(vehicles);
}).WithTags("Vehicle");

app.MapGet("/vehicle/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.FindById(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(vehicle);
}).WithTags("Vehicle");

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
}).WithTags("Vehicle");

app.MapDelete("/vehicle/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.FindById(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    vehicleService.Delete(vehicle);

    return Results.NoContent();
}).WithTags("Vehicle");
#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion