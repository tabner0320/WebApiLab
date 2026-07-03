# WebApiLab

WebApiLab is a .NET solution that demonstrates how to build and consume a RESTful Web API using ASP.NET Core Minimal APIs and a C# Console application.

## Features

* ASP.NET Core Minimal Web API
* Swagger API documentation
* Reads data from a JSON file
* REST endpoint that returns a list of people
* C# Console application that consumes the API using `HttpClient`
* JSON serialization and deserialization
* Asynchronous programming with `async` and `await`

## Technologies Used

* C#
* .NET 10
* ASP.NET Core Minimal API
* Swagger (Swashbuckle)
* HttpClient
* System.Text.Json
* Git & GitHub

## Project Structure

```text
WebApiLab
│
├── WebApiLab.API
│   ├── REST API
│   ├── Person Model
│   ├── Resources
│   └── Swagger
│
├── WebApiLab.Console
│   ├── HttpClient Consumer
│   └── Person Model
│
└── WebApiLab.slnx
```

## Getting Started

Clone the repository:

```bash
git clone https://github.com/tabner0320/WebApiLab.git
```

Navigate to the project:

```bash
cd WebApiLab
```

Restore packages:

```bash
dotnet restore
```

Build the solution:

```bash
dotnet build
```

## Running the API

```bash
dotnet run --project WebApiLab.API/WebApiLab.API.csproj
```

Open Swagger in your browser:

```
http://localhost:5267/swagger
```

> Replace the port number with the one shown in your terminal if it is different.

## Running the Console Application

With the API running in a separate terminal:

```bash
dotnet run --project WebApiLab.Console/WebApiLab.Console.csproj
```

The console application retrieves data from the Web API and displays the list of people.

## Learning Objectives

This project demonstrates:

* Building REST APIs with ASP.NET Core
* Creating Minimal APIs
* Reading JSON data
* Creating C# models
* Using HttpClient to consume APIs
* Working with async/await
* Organizing multi-project .NET solutions

## Author

**Theophilus Abner**

GitHub: https://github.com/tabner0320
