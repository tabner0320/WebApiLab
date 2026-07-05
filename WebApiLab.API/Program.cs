using System.Text.Json;
using WebApiLab.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

string jsonFile = File.ReadAllText("./Resources/64KB.json");

var jsonData = JsonSerializer.Deserialize<List<Person>>(
    jsonFile,
    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapGet("/people", () => jsonData)
    .WithName("GetPeople")
    .Produces<List<Person>>(StatusCodes.Status200OK);

app.MapControllers();

app.Run();