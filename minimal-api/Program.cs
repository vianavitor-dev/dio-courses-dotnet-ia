using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domain.Entities;
using minimal_api.Domain.Services;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.Services;
using MinimalApi.DTOs;
using MinimalApi.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IVehicalService, VehicalService>();

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


app.MapGet("/", () => "Hello World!");
app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministratorService administratorService) =>
{
    if (administratorService.Login(loginDTO) == null)
    {
        return Results.Unauthorized();
    } 

    return Results.Ok("User logged");
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();