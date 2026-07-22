using System.Text.Json;
using WebApiLab.Console.Models;

HttpClient client = new HttpClient
{
    BaseAddress = new Uri("http://localhost:5267")
};

try
{
    HttpResponseMessage response = await client.GetAsync("/people");

    if (response.IsSuccessStatusCode)
    {
        string json = await response.Content.ReadAsStringAsync();

        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );

        if (people is not null)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(
                    $"{person.Name} - {person.Id}"
                );
            }
        }
    }
    else
    {
        Console.WriteLine(
            $"Unable to retrieve people: {response.StatusCode}"
        );
    }

    Console.WriteLine();
    Console.WriteLine("Getting one person by ID...");

    string personId = "V59OF92YF627HFY0";

    HttpResponseMessage personResponse =
        await client.GetAsync($"/people/{personId}");

    if (personResponse.IsSuccessStatusCode)
    {
        string personJson =
            await personResponse.Content.ReadAsStringAsync();

        Person? person = JsonSerializer.Deserialize<Person>(
            personJson,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );

        if (person is not null)
        {
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"ID: {person.Id}");
            Console.WriteLine($"Language: {person.Language}");
            Console.WriteLine($"Bio: {person.Bio}");
            Console.WriteLine($"Version: {person.Version}");
        }
    }
    else if (
        personResponse.StatusCode ==
        System.Net.HttpStatusCode.NotFound)
    {
        Console.WriteLine(
            $"No person was found with ID {personId}."
        );
    }
    else
    {
        Console.WriteLine(
            $"Request failed: {personResponse.StatusCode}"
        );
    }
}
catch (HttpRequestException ex)
{
    Console.WriteLine(
        $"Could not connect to the API: {ex.Message}"
    );
}