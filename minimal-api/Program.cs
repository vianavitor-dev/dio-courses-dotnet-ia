using MinimalApi.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email != "admin@test.com" && loginDTO.Password != "123456")
    {
        return Results.Unauthorized();
    } 

    return Results.Ok("User logged");
});

app.Run();