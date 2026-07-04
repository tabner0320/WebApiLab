using System.Text.Json;
using WebApiLab.Console.Models;

HttpClient client = new HttpClient();

client.BaseAddress = new Uri("http://localhost:5267");

// Lookup one person by ID
HttpResponseMessage response =
    await client.GetAsync("/api/People/V59OF92YF627HFY0");

if (response.IsSuccessStatusCode)
{
    string json = await response.Content.ReadAsStringAsync();

    Person? person = JsonSerializer.Deserialize<Person>(
        json,
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

    Console.WriteLine($"Name: {person?.Name}");
    Console.WriteLine($"Language: {person?.Language}");
    Console.WriteLine($"ID: {person?.Id}");
    Console.WriteLine($"Bio: {person?.Bio}");
    Console.WriteLine($"Version: {person?.Version}");
}
else
{
    Console.WriteLine($"Error: {response.StatusCode}");
}