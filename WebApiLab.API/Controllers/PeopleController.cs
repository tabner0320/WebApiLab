using Microsoft.AspNetCore.Mvc;
using WebApiLab.API.Models;

namespace WebApiLab.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly List<Person> people;

    public PeopleController()
    {
        string jsonFile = System.IO.File.ReadAllText("./Resources/64KB.json");

        people = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(
            jsonFile,
            new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        ) ?? new List<Person>();
    }

    [HttpGet]
    public ActionResult<List<Person>> GetPeople()
    {
        return Ok(people);
    }

    [HttpGet("{id}")]
    public ActionResult<Person> GetPerson(string id)
    {
        Person? person = people.FirstOrDefault(p => p.Id == id);

        if (person is null)
        {
            return NotFound();
        }

        return Ok(person);
    }
}