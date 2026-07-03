using System.Text.Json;
using WebApiLab.Console.Models;

HttpClient client = new HttpClient();

client.BaseAddress = new Uri("http://localhost:5267");

HttpResponseMessage response = await client.GetAsync("/people");

if (response.IsSuccessStatusCode)
{
    string content = await response.Content.ReadAsStringAsync();

    var people = JsonSerializer.Deserialize<List<Person>>(
        content,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    foreach (Person person in people!)
    {
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Language: {person.Language}");
        Console.WriteLine($"ID: {person.Id}");
        Console.WriteLine($"Bio: {person.Bio}");
        Console.WriteLine($"Version: {person.Version}");
        Console.WriteLine("-------------------------");
    }
}
else
{
    Console.WriteLine($"Error: {response.StatusCode}");
    Console.WriteLine(await response.Content.ReadAsStringAsync());
}
