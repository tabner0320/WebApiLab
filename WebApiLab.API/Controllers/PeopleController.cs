using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiLab.API.Models;

namespace WebApiLab.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private List<Person> People { get; set; } = [];

    public PeopleController()
    {
        string jsonFile = System.IO.File.ReadAllText("./Resources/64KB.json");

        People = JsonSerializer.Deserialize<List<Person>>(
            jsonFile,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? throw new Exception("No people data found.");
    }

    [HttpGet]
    public IActionResult GetPeople()
    {
        return Ok(People);
    }
}